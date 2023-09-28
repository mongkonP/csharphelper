

namespace howto_load_runtime_enum

{

    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class JobTitle : System.Attribute
    {
        public string Value;
        public JobTitle(string value)
        {
            Value = value;
        }
    }

    // Note: An attribute's type cannot be float
    // because float is not a "simple" type.
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class Salary : System.Attribute
    {
        public float Value;
        public Salary(float value)
        {
            Value = value;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class IsExempt : System.Attribute
    {
        public bool Value;
        public IsExempt(bool value)
        {
            Value = value;
        }
    }


    // Attributes.
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class CustomerType : System.Attribute
    {
        public string TypeName;
        public float Discount;
        public CustomerType(string type_name, float discount)
        {
            TypeName = type_name;
            Discount = discount;
        }
    }

    // Enums.
    enum Employees
    {
        [IsExempt(false)]
        Clerk,
        [JobTitle("Super"), IsExempt(false)]
        Supervisor,
        [JobTitle("Manager"), Salary(84000), IsExempt(true)]
        Manager,
        [JobTitle("Admin"), Salary(72000), IsExempt(true)]
        Administrator,
    }

    enum Customers
    {
        [CustomerType("Retail", 0)]
        Customer,
        [CustomerType("Frequent", 10)]
        FrequentBuyer,
        [CustomerType("Wholesale", 40)]
        Wholesale,

    }
}