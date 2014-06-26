using System.Collections;
using UnityEngine;

public class ParsedData
{
    public enum Type
    {
        CLICK,
        INSTALL,
        NONE
    };

    //We can add more attributes if we want more filters.
    public string m_id;
    public string m_type;

    public ParsedData(string _id, string _type)
    {
        m_id = _id;
        m_type = _type;
    }

    public Type getType()
    {
        if (m_type == "install")
        {
            return Type.INSTALL;
        }
        if (m_type == "click")
        {
            return Type.CLICK;
        }
        else
        {
            return Type.NONE;
        }
    }
}
