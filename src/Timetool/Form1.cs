using System.Globalization;
using System.Text.RegularExpressions;

namespace Timetool;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void txtInput_TextChanged(object sender, EventArgs e)
    {
        var regularFont = txtOutput.SelectionFont;
        txtOutput.Clear();
        txtOutput.DeselectAll();

        using (var boldFont = new Font(regularFont, FontStyle.Bold))
        {
            var offsetInput = txtInput.Text;
            TimeSpan timeOffset = TimeSpan.Zero;
            // "s" suffix denotes seconds
            if (Regex.IsMatch(offsetInput, "^[0-9]+s$"))
            {
                txtOutput.AppendText("Parsed seconds\r\n");

                timeOffset = TimeSpan.FromSeconds(Int32.Parse(CutLastChars(1, offsetInput)));
                txtOutput.SelectionFont = boldFont;
                txtOutput.AppendText(timeOffset.ToString("hh':'mm':'ss", CultureInfo.InvariantCulture));
            }
            else if (offsetInput.Contains(':') || offsetInput.Contains(','))
            {
                txtOutput.AppendText("Parsed timestamp to seconds\r\n");

                timeOffset = ParseHoursMinutesSecondsAndMillis(offsetInput);
                txtOutput.SelectionFont = boldFont;
                txtOutput.AppendText(timeOffset.TotalSeconds.ToString());
            }
            else
            {
                int milliSecondsValue;
                if (Int32.TryParse(offsetInput, out milliSecondsValue))
                {
                    txtOutput.AppendText("Parsed milliseconds\r\n");

                    timeOffset = TimeSpan.FromMilliseconds(milliSecondsValue);
                    txtOutput.SelectionFont = boldFont;
                    //txtOutput.AppendText(timeOffset.ToString("hh':'mm':'ss[','fff]", CultureInfo.InvariantCulture));
                    txtOutput.AppendText(timeOffset.ToString("hh':'mm':'ss\\,fff", CultureInfo.InvariantCulture));
                }
                else
                {
                    txtOutput.AppendText("Unrecognized input format");
                }
            }
        }
        txtOutput.SelectionFont = regularFont;

    }
    public static string CutLastChars(int number, string input)
    {
        return input.Substring(0, input.Length - number);
    }


    // Hours:Minutes:Seconds,millis (note: millis should either have 3 digits or be considered left-padded with zeroes)
    // This means "1,5" means 1 second + 5 millis, not one-and-a-half second
    private static TimeSpan ParseHoursMinutesSecondsAndMillis(string offsetInput)
    {
        TimeSpan jump = TimeSpan.Zero;
        // Either hours or minutes were found
        if (Regex.IsMatch(offsetInput, "^[0-9]+:"))
        {
            int colonOffset = offsetInput.IndexOf(":");
            jump = TimeSpan.FromMinutes(Int32.Parse(offsetInput.Substring(0, colonOffset)));
            offsetInput = offsetInput.Substring(colonOffset + 1);
        }

        // If there's still a colon then we found a minutes part
        if (Regex.IsMatch(offsetInput, "^[0-9]+:"))
        {
            jump = TimeSpan.FromTicks(jump.Ticks * 60); // If there was an hours component earlier on

            int colonOffset = offsetInput.IndexOf(":");
            jump = jump.Add(TimeSpan.FromMinutes(Int32.Parse(offsetInput.Substring(0, colonOffset))));
            offsetInput = offsetInput.Substring(colonOffset + 1);
        }
        else if (offsetInput.StartsWith(":"))
        {
            jump = TimeSpan.FromTicks(jump.Ticks * 60); // If there was an hours component earlier on
            offsetInput = offsetInput.Substring(1);
        }

        string seconds = String.Empty;
        string milliSeconds = String.Empty;
        if (Regex.IsMatch(offsetInput, "^[0-9]+,"))
        {
            int commaOffset = offsetInput.IndexOf(",");
            seconds = offsetInput.Substring(0, commaOffset);
            offsetInput = offsetInput.Substring(commaOffset + 1);
        }
        else if (Regex.IsMatch(offsetInput, "^[0-9]+$"))
        {
            seconds = offsetInput;
            offsetInput = String.Empty;
        }
        else if (offsetInput.StartsWith(","))
        {
            offsetInput = offsetInput.Substring(1);
        }

        milliSeconds = offsetInput;

        if (!String.IsNullOrWhiteSpace(seconds))
        {
            jump = jump.Add(TimeSpan.FromSeconds(Int32.Parse(seconds)));
        }

        if (!String.IsNullOrWhiteSpace(milliSeconds))
        {
            jump = jump.Add(TimeSpan.FromMilliseconds(Int32.Parse(milliSeconds)));
        }

        return jump;
    }

}
