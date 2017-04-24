namespace TM_Impronet_Interface.Classes
{
    public class ComboBoxItemCostCentre
    {
        public override string ToString()
        {
            return $"{ItemObject.Description} ({ItemObject.Code})";
        }

        public CostCentre ItemObject { get; set; }
    }

    public class ComboBoxItemDepartment
    {
        public override string ToString()
        {
            return $"{ItemObject.Name} ({ItemObject.Id})";
        }

        public Department ItemObject { get; set; }
    }

    public class ComboBoxItemCompany
    {
        public override string ToString()
        {
            return $"{ItemObject.Description} ({ItemObject.Code})";
        }

        public Company ItemObject { get; set; }
    }
}
