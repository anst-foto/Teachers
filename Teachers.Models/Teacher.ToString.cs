using System.Text;

namespace Teachers.Models;

public partial class Teacher
{
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Teacher: {");

        var type = this.GetType();
        var properties = type.GetProperties();
        foreach (var propertyInfo in properties)
        {
            var name = propertyInfo.Name;
            var value = propertyInfo.GetValue(this);

            if (propertyInfo.PropertyType.IsGenericType)
            {
                var list = (List<string>)value;
                sb.AppendLine($"\t{name}: [{string.Join(", ", list)}]") ;
            }
            else
            {
                sb.AppendLine($"\t{name}: {value}");
            }

        }

        sb.AppendLine("}");

        return sb.ToString();
    }
}
