/*
 * 
 * Copyright (c) 2015 All Rights Reserved, VERGOSOFT LLC
 * Title: VundaBall
 * Author: Scott Zastrow
 * iOS Version: 1.2
 * 
 * 
 */
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("DataCollection")]
public class xmlContainer {

    [XmlArray("GameData")]
    [XmlArrayItem("xmlData")]

    public xmlData[] GameData;


    public void Save(string fileName) 
    {
        using (var stream = new FileStream(fileName, FileMode.Create))
        {
            XmlSerializer XML = new XmlSerializer(typeof(xmlData));
            XML.Serialize(stream, this);

        }
    }
}
