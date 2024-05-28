using Microsoft.Toolkit.Uwp.Notifications;
using System.Drawing.Text;
using System.Media;
using System.Text;
using System.Timers;
using Timer = System.Timers.Timer;

namespace SitStandTimer
{
    public enum State
    {
        Sit,
        Stand
    }
    public partial class Form1 : Form
    {
        Random rand = new Random();
        private string _directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        private string bloonTip = "Sit";

        private State nextState = State.Stand;
        private State currentState = State.Sit;

        public int standTime;
        public int sitTime;

        (string comboBoxItemId, string comboBoxItemContent)[] delayChoices = new[] {
            (comboBoxItemId: "10", comboBoxItemContent: "10 Minutes"),
            (comboBoxItemId: "30", comboBoxItemContent: "30 Minutes"),
            (comboBoxItemId: "60", comboBoxItemContent: "1 Hour"),
            (comboBoxItemId: "180", comboBoxItemContent: "3 Hours"),
            (comboBoxItemId: "a", comboBoxItemContent: "Close App")
        };

        private Timer timer;

        public Form1()
        {
            InitializeComponent();

            ShowInTaskbar = false;
            notifyIcon.Text = bloonTip;

            ToastNotificationManagerCompat.OnActivated += toastArgs => RunToastActivated(toastArgs);

            string savedValues;
            try
            {
                using (StreamReader reader = new StreamReader(Path.Combine(_directory, "SaveData.txt")))
                {
                    savedValues = reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                savedValues = "50,10";
                using (FileStream fs = new FileStream(Path.Combine(_directory, "SaveData.txt"), FileMode.CreateNew))
                {
                    fs.WriteAsync(Encoding.ASCII.GetBytes(savedValues));
                }
            }

            var values = savedValues.Split(',');

            sitTime = int.Parse(values[0]);
            standTime = int.Parse(values[1]);

            standNumericUpDown.Value = standTime;
            sitNumericUpDown.Value = sitTime;

            timer = new Timer();
            SetTimer(sitTime);
            timer.Elapsed += OnTimedEvent;
        }

        private void SetTimer(int time = 1)
        {
            timer.Interval = time * 60000;
            timer.Start();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            ToastNotificationManagerCompat.History.Clear();
            timer.Stop();
            //SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Alarm05.wav");
            //simpleSound.Play();

            ShowNotification();

            //currentState = nextState;
            //switch (currentState)
            //{
            //    case State.Sit:
            //        nextState = State.Stand;
            //        break;
            //    case State.Stand:
            //        nextState = State.Sit;
            //        break;
            //}

            SetTimer();
        }

        private void ShowNotification(int delayTime = 0)
        {
            int duration = 0;
            switch (nextState)
            {
                case State.Sit:
                    duration = sitTime;
                    break;
                case State.Stand:
                    duration = standTime;
                    break;
            }

            new ToastContentBuilder().AddText("Alarm!").AddText($"{currentState} has ended.\r\nPlease {nextState} for the next {duration} minutes")
                .SetToastDuration(ToastDuration.Long)
                .AddArgument("button", "none")
                .AddComboBox("delay", delayChoices)
                .AddButton(new ToastButton().SetContent("OK").AddArgument("button", "accept"))
                .AddButton(new ToastButton().SetContent($"{currentState} Again").AddArgument("button", "repeat"))
                .AddButton(new ToastButton().SetContent("Pause").AddArgument("button", "pause"))
                .AddAudio(new Uri(@$"c:\Windows\Media\Alarm{rand.Next(1, 11).ToString("D2")}.wav"))
                .Show();
        }

        private void RunToastActivated(ToastNotificationActivatedEventArgsCompat toastArgs)
        {
            ToastArguments args = ToastArguments.Parse(toastArgs.Argument);


            switch (args["button"])
            {
                case "none":
                    this.Invoke((MethodInvoker)(() =>
                    {
                        WindowState = FormWindowState.Normal;
                        ShowInTaskbar = true;
                    }));
                    break;
                case "accept":
                    SwitchToState(nextState);
                    break;
                case "repeat":
                    SwitchToState(currentState);
                    break;
                case "pause":
                    int delayTimer;
                    if (toastArgs.UserInput.TryGetValue("delay", out object delayInput))
                    {
                        if (string.IsNullOrEmpty(delayInput.ToString()))
                            return;
                        if (int.TryParse(delayInput.ToString(), out delayTimer))
                        {
                            SetTimer(delayTimer);
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    break;

            }
        }

        private void SwitchToState(State stateToBecome)
        {
            switch (stateToBecome)
            {
                case State.Sit:
                    SetTimer(sitTime);
                    nextState= State.Stand;
                    break;
                case State.Stand:
                    SetTimer(standTime);
                    nextState= State.Sit;
                    break;
            }


            currentState = stateToBecome;

            notifyIcon.Text = currentState.ToString();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                //this.
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            timer.Stop();

            notifyIcon.Text = currentState.ToString();

            standTime = (int)standNumericUpDown.Value;
            sitTime = (int)sitNumericUpDown.Value;

            string savedValues = $"{sitTime},{standTime}";

            File.WriteAllText(Path.Combine(_directory, "SaveData.txt"), savedValues);

            switch (currentState)
            {
                case State.Sit:
                    SetTimer(sitTime);
                    break;
                case State.Stand:
                    SetTimer(standTime);
                    break;
            }
        }
    }
}