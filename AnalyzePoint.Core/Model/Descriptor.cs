using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzePoint.Core.Model
{
  /// <summary>
  /// This is a base class for describing all SharePoint components.
  /// </summary>
  public abstract class Descriptor : IEquatable<Descriptor>, IComparable<Descriptor>
  {
    public Guid ID { get; protected set; }
    public virtual string Name { get; set; }
    public virtual string DisplayName { get; set; }
    public virtual bool IsDeployed { get; set; }

    public Descriptor(Guid identifier, string name, string displayName)
    {
      ID = identifier;
      Name = name;
      DisplayName = displayName;
    }

    public Descriptor()
    {

    }

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;

      Descriptor anotherObject = obj as Descriptor;

      if (anotherObject == null)
        return false;

      return
        anotherObject.ID == this.ID &&
        anotherObject.Name == this.Name &&
        anotherObject.DisplayName == this.DisplayName &&
        anotherObject.IsDeployed == this.IsDeployed;
    }

    public virtual bool Equals(Descriptor other)
    {
      return
        other.ID == this.ID &&
        other.Name == this.Name &&
        other.DisplayName == this.DisplayName &&
        other.IsDeployed == this.IsDeployed;
    }

    public int CompareTo(Descriptor other)
    {
      int displayNameComparison = this.DisplayName.CompareTo(other.DisplayName);
      int nameComparison = this.Name.CompareTo(other.Name);
      int idComparison = this.ID.CompareTo(other.ID);

      if (displayNameComparison == 0)
      {
        if (nameComparison == 0)
        {
          return idComparison;
        }
        else
        {
          return nameComparison;
        }
      }
      else
      {
        return displayNameComparison;
      }
    }

    public override int GetHashCode()
    {
      var hashCode = 1024679948;
      hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(ID);
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DisplayName);
      return hashCode;
    }

    public static bool operator <(Descriptor baseDescriptor1, Descriptor baseDescriptor2)
    {
      return baseDescriptor1.CompareTo(baseDescriptor2) < 0;
    }

    public static bool operator >(Descriptor baseDescriptor1, Descriptor baseDescriptor2)
    {
      return baseDescriptor1.CompareTo(baseDescriptor2) > 0;
    }

    public static bool operator <=(Descriptor baseDescriptor1, Descriptor baseDescriptor2)
    {
      return baseDescriptor1.CompareTo(baseDescriptor2) <= 0;
    }

    public static bool operator >=(Descriptor baseDescriptor1, Descriptor baseDescriptor2)
    {
      return baseDescriptor1.CompareTo(baseDescriptor2) >= 0;
    }

    public static bool operator ==(Descriptor descriptor1, Descriptor descriptor2)
    {
      return EqualityComparer<Descriptor>.Default.Equals(descriptor1, descriptor2);
    }

    public static bool operator !=(Descriptor descriptor1, Descriptor descriptor2)
    {
      return !(descriptor1 == descriptor2);
    }


  }
}
