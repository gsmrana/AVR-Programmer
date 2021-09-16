using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;


namespace AVR_Programmer
{
    public partial class MainForm : Form
    {
        #region Data

        string _hexFileName = "firmware_build.hex";
        string _cliExecutableFullname = "";
        bool _cmdlineToolFound = false;

        // command line params
        string _debugger = "ATMELICE";
        string _mcu = "ATxmega32E5";
        string _interface = "PDI";
        string _clock = "4mhz";
        string _section = "--flash";

        readonly string ParamFile = "param.dat";
        readonly string AstricsLine = "*****************************************************";
        readonly string CliExecutableName = "atprogram.exe";
        readonly string[] CliPathList =
        {
            @"CLI\atbackend\atprogram.exe",
            @"C:\Program Files\Atmel\Studio\7.0\atbackend\atprogram.exe",
            @"C:\Program Files (x86)\Atmel\Studio\7.0\atbackend\atprogram.exe",
        };

        #endregion

        #region ctor

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            rtbEventLog.Font = new Font("Consolas", 9);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                Text = string.Format("{0} - v{1}", Text, Assembly.GetExecutingAssembly().GetName().Version);
                AppendEventLog(AstricsLine);
                AppendEventLog("Developed by GSM Rana");
                AppendEventLog("https://github.com/gsmrana");

                if (!File.Exists(ParamFile)) throw new Exception("Programmer Parameter Data File Not Found!");
                var lines = File.ReadAllLines(ParamFile);

                comboBoxMcu.Items.AddRange(lines[0].Split(','));
                comboBoxFTool.Items.AddRange(lines[1].Split(','));
                comboBoxIface.Items.AddRange(lines[2].Split(','));
                comboBoxClock.Items.AddRange(lines[3].Split(','));
                comboBoxMcu.SelectedIndex = 2;
                comboBoxFTool.SelectedIndex = 0;
                comboBoxIface.SelectedIndex = 2;
                comboBoxClock.SelectedIndex = 3;
                textBoxFirmwareFile.Text = _hexFileName;

                SearchCommandlineTool();
                if (_cmdlineToolFound)
                {
                    Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            Thread.Sleep(300);
                            AppendEventLog(AstricsLine);
                            AppendEventLog("Using CLI: \r\n" + _cliExecutableFullname + "\n");
                            //ExecuteCommandLine("--help");
                            //ExecuteCommandLine("--version");
                            ExecuteCommandLine("version");
                            ExecuteCommandLine("list");
                        }
                        catch (Exception) { }
                        AppendEventLog(AstricsLine);
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Helper Methods

        private void AppendEventLog(string str, bool appendNewLine = true, Color? color = null)
        {
            var textclr = color ?? Color.Blue;
            if (appendNewLine)
                str += Environment.NewLine;

            if (str.IndexOf("ERROR", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                textclr = Color.Magenta;


            // update UI from dispatcher thread
            Invoke(new MethodInvoker(() =>
            {
                rtbEventLog.SelectionStart = rtbEventLog.TextLength;
                rtbEventLog.SelectionLength = 0;
                rtbEventLog.SelectionColor = textclr;
                rtbEventLog.AppendText(str);
                if (!rtbEventLog.Focused)
                    rtbEventLog.ScrollToCaret();
            }));
        }

        void SearchCommandlineTool()
        {
            foreach (var filename in CliPathList)
            {
                if (File.Exists(filename))
                {
                    _cliExecutableFullname = filename;
                    _cmdlineToolFound = true;
                    return;
                }
            }

            AppendEventLog(AstricsLine);
            var errorstr = CliExecutableName + " CLI executable not found in following paths: ";
            foreach (var item in CliPathList) errorstr += "\n" + item;
            AppendEventLog(errorstr, true, Color.Magenta);

            errorstr = CliExecutableName + "\nCLI executable not found!";
            MessageBox.Show(errorstr, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            var ofd = new OpenFileDialog
            {
                Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*",
                FileName = CliExecutableName
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetFileName(ofd.FileName) == CliExecutableName)
                {
                    _cliExecutableFullname = ofd.FileName;
                    _cmdlineToolFound = true;
                }
                else
                {
                    errorstr = "Invalid CLI executable file selected!";
                    AppendEventLog(errorstr, true, Color.Magenta);
                    MessageBox.Show(errorstr, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (!_cmdlineToolFound)
            {
                AppendEventLog("Please install Microchip Studio to resolve this problem!");
                AppendEventLog("https://www.microchip.com/en-us/development-tools-tools-and-software/microchip-studio-for-avr-and-sam-devices#Downloads");
            }

            AppendEventLog(AstricsLine);
        }

        void GetCommnadLineParams()
        {
            _mcu = comboBoxMcu.Text;
            _debugger = comboBoxFTool.Text;
            _interface = comboBoxIface.Text;
            _clock = comboBoxClock.Text;
            _section = radioButtonFlash.Checked ? "--flash" : "--eeprom";
        }

        #endregion

        #region CLI Execution

        public void ExecuteCommandLine(string args)
        {
            var inf = new ProcessStartInfo(_cliExecutableFullname)
            {
                Arguments = args,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                WorkingDirectory = Path.GetDirectoryName(_cliExecutableFullname)
            };

            var process = new Process { StartInfo = inf };
            process.ErrorDataReceived += Process_ErrorDataReceived;
            process.OutputDataReceived += Process_OutputDataReceived;
            _errorFromCli = false;
            _cliErrorMessage = "";
            process.Start();

            //var output = process.StandardError.ReadToEnd();
            //output += process.StandardOutput.ReadToEnd();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();

            //process.WaitForExit();
            var sw = new Stopwatch();
            sw.Start();
            while (!process.HasExited)
            {
                Application.DoEvents();
                if (_errorFromCli) throw new Exception("Error message from CLI: ");

                if (sw.ElapsedMilliseconds > 15000)
                {
                    process.Kill();
                    throw new Exception("CLI execution timeout!");
                }
            }
        }

        bool _errorFromCli = false;
        string _cliErrorMessage = "";

        void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null) return;
            AppendEventLog(e.Data);

            if (e.Data.IndexOf("ERROR", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                _cliErrorMessage = e.Data;
                _errorFromCli = true;
            }
        }

        void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null) return;
            AppendEventLog(e.Data);
        }

        #endregion

        #region UI Events

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (radioButtonFlash.Checked) ofd.Filter = "Hex Files (*.hex)|*.hex|All Files (*.*)|*.*";
            else ofd.Filter = "Eep Files (*.eep)|*.eep|All Files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _hexFileName = ofd.FileName;
                AppendEventLog("Selected firmware: ");
                AppendEventLog(_hexFileName); ;
                textBoxFirmwareFile.Text = Path.GetFileName(ofd.FileName);
                buttonProgram.Focus();
            }
        }

        private void ButtonCheck_Click(object sender, EventArgs e)
        {
            buttonCheck.Enabled = false;
            AppendEventLog(AstricsLine);
            Application.DoEvents();

            try
            {
                _cliErrorMessage = "";
                GetCommnadLineParams();
                Application.DoEvents();

                var cli = "";
                if (!checkBoxInfoCheck.Checked)
                {
                    AppendEventLog("Reading Target Voltage... ");
                    cli = "-f parameters --voltage";
                }
                else
                {
                    AppendEventLog("Reading Info...\r\n");
                    cli = string.Format("-t {0} -i {1} -d {2} -cl {3} -f info", _debugger, _interface, _mcu, _clock);
                }

                ExecuteCommandLine(cli);
                AppendEventLog(AstricsLine);
            }
            catch (Exception ex)
            {
                AppendEventLog(AstricsLine);
                Application.DoEvents();
                MessageBox.Show(ex.Message + "\r\n" + _cliErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            buttonCheck.Enabled = true;
            buttonCheck.Focus();
            Application.DoEvents();
        }

        private void ButtonRead_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            if (radioButtonFlash.Checked)
            {
                sfd.Filter = "Hex Files (*.hex)|*.hex|All Files (*.*)|*.*";
                sfd.FileName = "FlashRead.hex";
            }
            else
            {
                sfd.Filter = "Eep Files (*.eep)|*.eep|All Files (*.*)|*.*";
                sfd.FileName = "EepromRead.eep";
            }

            string filename;
            if (sfd.ShowDialog() == DialogResult.OK)
                filename = sfd.FileName;
            else return;

            buttonRead.Enabled = false;
            buttonRead.Text = "Reading...";
            progressBar1.Value = 0;
            AppendEventLog(AstricsLine);
            Application.DoEvents();

            try
            {
                _cliErrorMessage = "";
                GetCommnadLineParams();

                if (checkBoxInterfaceCheck.Checked)
                {
                    AppendEventLog("Checking target voltage...");
                    ExecuteCommandLine(string.Format("-f parameters --voltage"));
                    progressBar1.Value = 15;
                    Application.DoEvents();

                    AppendEventLog("Checking target interface...");
                    ExecuteCommandLine(string.Format("-t {0} -i {1} -d {2} -cl {3} -f info", _debugger, _interface, _mcu, _clock));
                    progressBar1.Value = 20;
                    Application.DoEvents();
                }

                AppendEventLog(string.Format("\r\nReading {0}...\r\n", _section.Substring(2).ToUpper()));
                ExecuteCommandLine(string.Format("-t {0} -i {1} -d {2} -cl {3} -f read {4} --file \"{5}\"", _debugger, _interface, _mcu, _clock, _section, filename));

                progressBar1.Value = 100;
                AppendEventLog(AstricsLine);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                AppendEventLog(AstricsLine);
                Application.DoEvents();
                MessageBox.Show(ex.Message + "\r\n" + _cliErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Value = 0;
            }

            buttonRead.Text = "Read";
            buttonRead.Enabled = true;
            buttonRead.Focus();
            Application.DoEvents();
        }

        private void ButtonProgram_Click(object sender, EventArgs e)
        {
            groupBoxParam.Enabled = false;
            buttonProgram.Enabled = false;
            buttonProgram.Text = "Programming...";
            progressBar1.Value = 0;
            Application.DoEvents();

            try
            {
                _cliErrorMessage = "";
                AppendEventLog(AstricsLine);
                if (!File.Exists(_hexFileName))
                {
                    var message = "Firmware file not selected or does not exist!";
                    AppendEventLog("[ERROR] " + message);
                    throw new Exception(message);
                }

                GetCommnadLineParams();
                Application.DoEvents();

                if (checkBoxInterfaceCheck.Checked)
                {
                    AppendEventLog("Checking target voltage...");
                    ExecuteCommandLine(string.Format("-f parameters --voltage"));
                    progressBar1.Value = 15;
                    Application.DoEvents();

                    AppendEventLog("Checking target interface...");
                    ExecuteCommandLine(string.Format("-t {0} -i {1} -d {2} -cl {3} -f info", _debugger, _interface, _mcu, _clock));
                    progressBar1.Value = 20;
                    Application.DoEvents();
                }

                if (checkBoxErase.Checked)
                {
                    AppendEventLog("\r\nErasing the chip...\r\n");
                    ExecuteCommandLine(string.Format("-t {0} -i {1} -d {2} -cl {3} -f chiperase", _debugger, _interface, _mcu, _clock));
                    progressBar1.Value = 40;
                    Application.DoEvents();
                }

                if (checkBoxWrite.Checked)
                {
                    AppendEventLog(string.Format("\r\nWriting {0}...", _section.Substring(2).ToUpper()));
                    ExecuteCommandLine(string.Format("-t {0} -i {1} -d {2} -cl {3} -f program {4} -f \"{5}\"", _debugger, _interface, _mcu, _clock, _section, _hexFileName));
                    progressBar1.Value = 70;
                    Application.DoEvents();
                }

                if (checkBoxVerify.Checked)
                {
                    AppendEventLog(string.Format("\r\nVerifying {0}...", _section.Substring(2).ToUpper()));
                    ExecuteCommandLine(string.Format("-t {0} -i {1} -d {2} -cl {3} -f verify {4} -f \"{5}\"", _debugger, _interface, _mcu, _clock, _section, _hexFileName));
                }

                progressBar1.Value = 100;
                AppendEventLog(AstricsLine);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                AppendEventLog(AstricsLine);
                Application.DoEvents();
                MessageBox.Show(ex.Message + "\r\n" + _cliErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Value = 0;
            }

            Application.DoEvents();
            buttonProgram.Text = "Program";
            buttonProgram.Enabled = true;
            groupBoxParam.Enabled = true;
            buttonProgram.Focus();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!buttonCheck.Enabled || !buttonRead.Enabled || !buttonProgram.Enabled)
                {
                    e.Cancel = true;
                }
            }
            catch { }
        }

        #endregion
    }
}
