using EsemkaHRSystem.Desktop.DataContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaHRSystem.Desktop
{
    public static class Helper
    {
        public static string PathBaseUrlImage = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Images\"));
        public static User UserLogin { get; set; } = new User();

        public static void ShowInformationMessage(this object o)
        {
            MessageBox.Show(o.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static int ToInt32(this object o) => Convert.ToInt32(o);

        public static void KeypressGlobal(this KeyPressEventArgs e)
        {
            // Check if the key pressed is a digit or a control key (e.g., backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If not a digit or control key, ignore the key press event
                e.Handled = true;
            }
        }

        public static void ClearField(this Control control)
        {
            control.Controls.OfType<TextBox>().ToList().ForEach(a => a.Clear());
            control.Controls.OfType<NumericUpDown>().ToList().ForEach(a => a.Value = 0);
            control.Controls.OfType<DateTimePicker>().ToList().ForEach(a => a.Value = DateTime.Now);
            control.Controls.OfType<CheckBox>().ToList().ForEach(a => a.Checked = false);
        }

        public static bool CheckIsEmpty(this Control control)
        {
            bool b1 = control.Controls.OfType<TextBox>().Where(a => string.IsNullOrWhiteSpace(a.Text)).Any();
            bool b2 = control.Controls.OfType<ComboBox>().Where(a => string.IsNullOrWhiteSpace(a.Text)).Any();

            return b1 || b2;
        }
    }
}