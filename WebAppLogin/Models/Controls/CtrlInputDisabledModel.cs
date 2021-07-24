namespace WebApp.Models.Controls
{
    public class CtrlInputDisabledModel : CtrlBaseModel
    {
        public string Type { get; set; }
        public string Label { get; set; }
        public string PlaceHolder { get; set; }
        public string ColumnDataName { get; set; }
        public string Disabled { get; set; }

        public CtrlInputDisabledModel()
        {
            ViewName = "";
        }
    }
}