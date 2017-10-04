using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using OutputChanger.Devices;

namespace OutputChanger.Changers
{
    /// <summary>
    /// Making changes to audio devices.
    /// </summary>
    public static class AudioChanger
    {
        /// <summary>
        /// Changes default audio device.
        /// </summary>
        public static void ChangeAudioDevice()
        {
            var devices = GetDevices();
            var currentDevice = devices.First(device => device.isSelected);
            int newId = currentDevice.id;

            if (newId == devices.Count - 1)
                newId = 0;
            else
                newId++;

            SelectDevice(newId);
        }

        #region EndPointController.exe interaction

        private static List<AudioDevice> GetDevices()
        {
            var p = new Process
            {
                StartInfo =
                                {
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true,
                                    FileName = "EndPointController.exe",
                                    Arguments = "-f \"%d|%ws|%d|%d\""
                                }
            };
            p.Start();
            p.WaitForExit();
            var stdout = p.StandardOutput.ReadToEnd().Trim();

            var devices = new List<AudioDevice>();

            foreach (var line in stdout.Split('\n'))
            {
                var elems = line.Trim().Split('|');
                var device = new AudioDevice(int.Parse(elems[0]) - 1, elems[1], elems[3].Equals("1"));
                devices.Add(device);
            }

            return devices;
        }

        private static void SelectDevice(int id)
        {

            var p = new Process
            {
                StartInfo =
                                {
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true,
                                    FileName = "EndPointController.exe",
                                    StandardOutputEncoding = Encoding.UTF8,
                                    Arguments = (id + 1).ToString(CultureInfo.InvariantCulture)
                                }
            };
            p.Start();
            p.WaitForExit();
        }
        #endregion
    }
}
