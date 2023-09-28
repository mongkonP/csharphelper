

  namespace  howto_remove_namespace

 { 

public class Person1
    {
        public string FirstName, LastName;
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}

public class Person1
{
    public string FirstName, LastName;
    public override string ToString()
    {
        return "[" + FirstName + " " + LastName + "]";
    }
}

public class Person2
{
    public string FirstName, LastName;
    public override string ToString()
    {
        return "[" + FirstName + " " + LastName + "]";
    }

}