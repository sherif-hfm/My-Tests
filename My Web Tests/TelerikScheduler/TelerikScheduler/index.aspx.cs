using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace TelerikScheduler
{
    public partial class index : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!IsPostBack)
            {
                Session.Remove(AppointmentsKey);

                InitializeResources();
                InitializeAppointments();
            }

            RadScheduler1.DataSource = Appointments;
        }

        private void InitializeResources()
        {
            ResourceType resType = new ResourceType("User");
            resType.ForeignKeyField = "UserID";

            RadScheduler1.ResourceTypes.Add(resType);
            RadScheduler1.Resources.Add(new Resource("User", 1, "Alex"));
            //RadScheduler1.Resources.Add(new Resource("User", 2, "Bob"));
            //RadScheduler1.Resources.Add(new Resource("User", 3, "Charlie"));
        }

        private void InitializeAppointments()
        {
            DateTime start = new DateTime(2016, 5, 31, 8, 0, 0);
            Appointments.Add(new AppointmentInfo("Appointment", start, start.AddMinutes(5), string.Empty, null, string.Empty, 1));
        }


        private const string AppointmentsKey = "Telerik.Web.Examples.Scheduler.BindToList.CS.Apts";

        private List<AppointmentInfo> Appointments
        {
            get
            {
                List<AppointmentInfo> sessApts = Session[AppointmentsKey] as List<AppointmentInfo>;
                if (sessApts == null)
                {
                    sessApts = new List<AppointmentInfo>();
                    Session[AppointmentsKey] = sessApts;
                }

                return sessApts;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void RadScheduler1_AppointmentClick(object sender, SchedulerEventArgs e)
        {
            txtData.Text = "AppointmentClick";
            //txtData.Text = e.Appointment.Start.ToString();
        }

        protected void RadScheduler1_AppointmentCommand(object sender, AppointmentCommandEventArgs e)
        {
            txtData.Text = "AppointmentCommand";
        }

        protected void RadScheduler1_AppointmentCreated(object sender, AppointmentCreatedEventArgs e)
        {
            txtData.Text = "Appointment Created" + e.Appointment.Start.ToString();
        }

        protected void RadScheduler1_AppointmentContextMenuItemClicked(object sender, AppointmentContextMenuItemClickedEventArgs e)
        {
            txtData.Text = "AppointmentContextMenuItemClicked";
        }

        protected void RadScheduler1_AppointmentContextMenuItemClicking(object sender, AppointmentContextMenuItemClickingEventArgs e)
        {

        }

        protected void RadScheduler1_AppointmentInsert(object sender, AppointmentInsertEventArgs e)
        {

        }

        protected void RadScheduler1_TimeSlotContextMenuItemClicked(object sender, TimeSlotContextMenuItemClickedEventArgs e)
        {

        }

        protected void RadScheduler1_TimeSlotCreated(object sender, TimeSlotCreatedEventArgs e)
        {
            e.TimeSlot.CssClass="timeSlot";
        }

        protected void RadScheduler1_NavigationCommand(object sender, SchedulerNavigationCommandEventArgs e)
        {

        }
    }


    class AppointmentInfo
    {
        private readonly string _id;
        private string _subject;
        private DateTime _start;
        private DateTime _end;
        private string _recurrenceRule;
        private string _recurrenceParentId;
        private string _reminder;
        private int? _userID;

        public string Description { get; set; }

        public string ID
        {
            get
            {
                return _id;
            }
        }

        public string Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                _subject = value;
            }
        }

        public DateTime Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
            }
        }

        public DateTime End
        {
            get
            {
                return _end;
            }
            set
            {
                _end = value;
            }
        }

        public string RecurrenceRule
        {
            get
            {
                return _recurrenceRule;
            }
            set
            {
                _recurrenceRule = value;
            }
        }

        public string RecurrenceParentID
        {
            get
            {
                return _recurrenceParentId;
            }
            set
            {
                _recurrenceParentId = value;
            }
        }

        public int? UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                _userID = value;
            }
        }

        public string Reminder
        {
            get
            {
                return _reminder;
            }
            set
            {
                _reminder = value;
            }
        }

        private AppointmentInfo()
        {
            _id = Guid.NewGuid().ToString();
        }

        public AppointmentInfo(string subject, DateTime start, DateTime end,
            string recurrenceRule, string recurrenceParentID, string reminder, int? userID)
            : this()
        {
            _subject = subject;
            _start = start;
            _end = end;
            _recurrenceRule = recurrenceRule;
            _recurrenceParentId = recurrenceParentID;
            _reminder = reminder;
            _userID = userID;
        }

        public AppointmentInfo(Appointment source) : this()
        {
            CopyInfo(source);
        }

        public void CopyInfo(Appointment source)
        {
            Subject = source.Subject;
            Start = source.Start;
            End = source.End;
            RecurrenceRule = source.RecurrenceRule;
            if (source.RecurrenceParentID != null)
            {
                RecurrenceParentID = source.RecurrenceParentID.ToString();
            }

            if (!String.IsNullOrEmpty(Reminder))
            {
                Reminder = source.Reminders[0].ToString();
            }

            Resource user = source.Resources.GetResourceByType("User");
            if (user != null)
            {
                UserID = (int?)user.Key;
            }
            else
            {
                UserID = null;
            }
        }
    }

}