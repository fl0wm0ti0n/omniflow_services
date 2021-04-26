namespace DataTransferObjects.Generic
{
    public class SettingsDto
    {
        public int SettingsEntityId { get; set; }
        public string Name { get; set; }
        public string ServiceTyp { get; set; }
        public string ServiceId { get; set; }
        public string System { get; set; }
        public string Category { get; set; }
        public string Value { get; set; }
    }
}