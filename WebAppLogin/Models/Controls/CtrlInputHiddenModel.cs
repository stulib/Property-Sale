namespace WebApp.Models.Controls
{
    public class CtrlInputHiddenModel : CtrlBaseModel
    {
        public string Type { get; set; }
        public string Label { get; set; }
        public string PlaceHolder { get; set; }
        public string ColumnDataName { get; set; }
        public string Hidden { get; set; }

        public CtrlInputHiddenModel()
        {
            ViewName = "";
        }
    }
}