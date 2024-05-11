using MultiShop.Shared.Enums;

namespace MultiShop.WebUI.Areas.User.Models
{
    public class TableColorList
    {
        private static List<string> _colors = new List<string>();
        public static List<string> Colors
        {
            get {

                _colors.Add(TableColorEnum.warning.ToString());
                _colors.Add(TableColorEnum.info.ToString());
                _colors.Add(TableColorEnum.danger.ToString());
                _colors.Add(TableColorEnum.success.ToString());
                _colors.Add(TableColorEnum.primary.ToString());
                return _colors; 
            
            }

        }
    }
}
