using EsemkaHRSystem.Desktop.DataContext;
using System;
using System.Windows.Forms;

namespace EsemkaHRSystem.Desktop.Forms
{
    public partial class MyScheduleUserConrol : UserControl
    {
        private readonly ScheduleDetail _scheduleDetail;

        public MyScheduleUserConrol(ScheduleDetail scheduleDetail)
        {
            InitializeComponent();
            _scheduleDetail = scheduleDetail;
        }

        private void MyScheduleUserConrol_Load(object sender, EventArgs e)
        {
            if (_scheduleDetail == null)
                return;

            tbDate.Text = _scheduleDetail.Date.ToString("ddd, dd MMM yyyy");
            tbStart.Text = _scheduleDetail.Time.TimeValue.ToString();
            tbEnd.Text = _scheduleDetail.Time2.TimeValue.ToString();
            tbBreak.Text = _scheduleDetail.Time1.TimeValue.ToString();
            tbDuration.Text = _scheduleDetail.BreakDuration.ToString();
        }
    }
}