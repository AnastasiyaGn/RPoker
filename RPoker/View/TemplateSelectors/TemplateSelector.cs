using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Model.Cards;

namespace View.TemplateSelectors
{
    public class TemplateSelector : DataTemplateSelector
    {
        #region DataTemplates
        public DataTemplate CA { get; set; }
        public DataTemplate CK { get; set; }
        public DataTemplate CQ { get; set; }
        public DataTemplate CJ { get; set; }
        public DataTemplate C10 { get; set; }
        public DataTemplate C9 { get; set; }
        public DataTemplate C8 { get; set; }
        public DataTemplate C7 { get; set; }
        public DataTemplate C6 { get; set; }
        public DataTemplate C5 { get; set; }
        public DataTemplate C4 { get; set; }
        public DataTemplate C3 { get; set; }
        public DataTemplate C2 { get; set; }
        public DataTemplate DA { get; set; }
        public DataTemplate DK { get; set; }
        public DataTemplate DQ { get; set; }
        public DataTemplate DJ { get; set; }
        public DataTemplate D10 { get; set; }
        public DataTemplate D9 { get; set; }
        public DataTemplate D8 { get; set; }
        public DataTemplate D7 { get; set; }
        public DataTemplate D6 { get; set; }
        public DataTemplate D5 { get; set; }
        public DataTemplate D4 { get; set; }
        public DataTemplate D3 { get; set; }
        public DataTemplate D2 { get; set; }
        public DataTemplate HA { get; set; }
        public DataTemplate HK { get; set; }
        public DataTemplate HQ { get; set; }
        public DataTemplate HJ { get; set; }
        public DataTemplate H10 { get; set; }
        public DataTemplate H9 { get; set; }
        public DataTemplate H8 { get; set; }
        public DataTemplate H7 { get; set; }
        public DataTemplate H6 { get; set; }
        public DataTemplate H5 { get; set; }
        public DataTemplate H4 { get; set; }
        public DataTemplate H3 { get; set; }
        public DataTemplate H2 { get; set; }
        public DataTemplate SA { get; set; }
        public DataTemplate SK { get; set; }
        public DataTemplate SQ { get; set; }
        public DataTemplate SJ { get; set; }
        public DataTemplate S10 { get; set; }
        public DataTemplate S9 { get; set; }
        public DataTemplate S8 { get; set; }
        public DataTemplate S7 { get; set; }
        public DataTemplate S6 { get; set; }
        public DataTemplate S5 { get; set; }
        public DataTemplate S4 { get; set; }
        public DataTemplate S3 { get; set; }
        public DataTemplate S2 { get; set; }
        public DataTemplate Back_red { get; set; }
        #endregion
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var card = item as Card;
            if (card != null)
            {
                if (card.IsHide)
                {
                    return Back_red;
                }
                var type = card.ToString();
                switch (type)
                {
                    #region switch cases
                    case "CA":
                        return CA;
                    case "CK":
                        return CK;
                    case "CQ":
                        return CQ;
                    case "CJ":
                        return CJ;
                    case "C10":
                        return C10;
                    case "C9":
                        return C9;
                    case "C8":
                        return C8;
                    case "C7":
                        return C7;
                    case "C6":
                        return C6;
                    case "C5":
                        return C5;
                    case "C4":
                        return C4;
                    case "C3":
                        return C3;
                    case "C2":
                        return C2;
                    case "DA":
                        return DA;
                    case "DK":
                        return DK;
                    case "DQ":
                        return DQ;
                    case "DJ":
                        return DJ;
                    case "D10":
                        return D10;
                    case "D9":
                        return D9;
                    case "D8":
                        return D8;
                    case "D7":
                        return D7;
                    case "D6":
                        return D6;
                    case "D5":
                        return D5;
                    case "D4":
                        return D4;
                    case "D3":
                        return D3;
                    case "D2":
                        return D2;
                    case "HA":
                        return HA;
                    case "HK":
                        return HK;
                    case "HQ":
                        return HQ;
                    case "HJ":
                        return HJ;
                    case "H10":
                        return H10;
                    case "H9":
                        return H9;
                    case "H8":
                        return H8;
                    case "H7":
                        return H7;
                    case "H6":
                        return H6;
                    case "H5":
                        return H5;
                    case "H4":
                        return H4;
                    case "H3":
                        return H3;
                    case "H2":
                        return H2;
                    case "SA":
                        return SA;
                    case "SK":
                        return SK;
                    case "SQ":
                        return SQ;
                    case "SJ":
                        return SJ;
                    case "S10":
                        return S10;
                    case "S9":
                        return S9;
                    case "S8":
                        return S8;
                    case "S7":
                        return S7;
                    case "S6":
                        return S6;
                    case "S5":
                        return S5;
                    case "S4":
                        return S4;
                    case "S3":
                        return S3;
                    case "S2":
                        return S2;
                    #endregion
                    default:
                        throw new NotSupportedException();
                }
            }
            else
                throw new NotSupportedException();
        }
    }
}
