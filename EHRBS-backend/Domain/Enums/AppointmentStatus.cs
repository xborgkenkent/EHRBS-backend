namespace EHRBS_backend.Domain.Enums
{
    public enum AppointmentStatus
    {
        Scheduled,    // Appointment is confirmed but not yet completed
        Completed,    // Appointment has been successfully conducted
        Canceled,     // Appointment was canceled by either party
        Rescheduled,  // Appointment has been moved to a new time
        NoShow,       // Patient did not show up for the appointment
        Pending,
    }
}
