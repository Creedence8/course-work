using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml; 

namespace editor
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        List<events> eventslist = new List<events>();
        List<intervals> intervalslist = new List<intervals>();
        string file="" ;
        public void load ()
        {
            int i = 0;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(file );
            XmlElement xRoot = xDoc.DocumentElement;

            
            XmlNodeList childnodes = xRoot.SelectNodes("//Interval"); 
            
            foreach (XmlNode n in childnodes)
            { 
                
                intervalslist.Add(new intervals() );
                intervalslist[i].name = n.SelectSingleNode("@Name").Value;
                XmlNode childnodes2 = n.FirstChild;
                if (childnodes2 != null)
                {
                  XmlNode a = childnodes2.FirstChild;
                  intervalslist[i].EqOp = a.SelectSingleNode("@Value").Value;
                 XmlNode b = a.FirstChild;
                 XmlNode c = a.LastChild;
                 intervalslist[i].Attribute = b.SelectSingleNode("@Value").Value;
                 intervalslist[i].string1 = c.SelectSingleNode("@Value").Value;
                } 
                
                XmlNode childnodes3 = n.LastChild;
                if (childnodes3 != null)
                {
                    XmlNode a = childnodes3.FirstChild;
                    intervalslist[i].EqOp2 = a.SelectSingleNode("@Value").Value;
                    XmlNode b = a.FirstChild;
                    XmlNode c = a.LastChild;
                    intervalslist[i].Attribute2 = b.SelectSingleNode("@Value").Value;
                    intervalslist[i].string12 = c.SelectSingleNode("@Value").Value;
                }
                comboBox1.Items.Add(intervalslist[i].name );
                i += 1;
            }
            i = 0;
            XmlNodeList childnodesev = xRoot.SelectNodes("//Event");

            foreach (XmlNode n in childnodesev)
            {
               
                eventslist.Add(new events());
                eventslist[i].name = n.SelectSingleNode("@Name").Value;        
                XmlNode childnodes2 = n.FirstChild ;
              
                    XmlNode a = childnodes2.FirstChild;
                    eventslist[i].EqOp = a.SelectSingleNode("@Value").Value;
                    XmlNode b = a.FirstChild;
                    XmlNode c = a.LastChild;
                    eventslist[i].Attribute = b.SelectSingleNode("@Value").Value;
                    eventslist[i].info = c.SelectSingleNode("@Value").Value;
                
                comboBox2.Items.Add(eventslist[i].name);
                i += 1;
            }

            
        }

        public void delete()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(file);
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("//Interval");
            if (childnodes.Count >0 )
            {
                foreach (XmlNode n in childnodes)
                {
                    if (lt1.Text == n.SelectSingleNode("@Name").Value)
                    {
                        n.ParentNode.RemoveChild(n);
                        xDoc.Save(file);
                        return;
                    }
                }
            }

            XmlNodeList childnodesev = xRoot.SelectNodes("//Event");
            if (childnodesev.Count>0)
            {
                foreach (XmlNode n in childnodesev)
                {
                    if (lt1.Text == n.SelectSingleNode("@Name").Value)
                    {
                        n.ParentNode.RemoveChild(n);
                        xDoc.Save(file);
                        break;
                    }
                }
            }
        }

        public void add()
        {
            if (file == "")
            { return; }
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(file);
            XmlElement xRoot = xDoc.DocumentElement;
            if (name1.Text!="")
            {
                //работаем с интервалами
                XmlElement intElem = xDoc.CreateElement("Interval");
                XmlAttribute nameAttr = xDoc.CreateAttribute("Name");
                XmlElement openElem = xDoc.CreateElement("Open");
                XmlElement eqopElem = xDoc.CreateElement("EqOp");
                XmlAttribute veAttr = xDoc.CreateAttribute("Value");
                XmlAttribute vaAttr = xDoc.CreateAttribute("Value");
                XmlAttribute vsAttr = xDoc.CreateAttribute("Value");
                XmlElement atElem = xDoc.CreateElement("Attribute");
                XmlElement stElem = xDoc.CreateElement("String");
                XmlElement closeElem = xDoc.CreateElement("Close");
                XmlElement eqop2Elem = xDoc.CreateElement("EqOp");
                XmlAttribute ve2Attr = xDoc.CreateAttribute("Value");
                XmlAttribute va2Attr = xDoc.CreateAttribute("Value");
                XmlAttribute vs2Attr = xDoc.CreateAttribute("Value");
                XmlElement at2Elem = xDoc.CreateElement("Attribute");
                XmlElement st2Elem = xDoc.CreateElement("String");
                XmlText nameText = xDoc.CreateTextNode(name1 .Text );
                XmlText eqText = xDoc.CreateTextNode(eqop1 .Text );
                XmlText atText = xDoc.CreateTextNode(atr1.Text );
                XmlText stText = xDoc.CreateTextNode(string1.Text );
                XmlText eq1Text = xDoc.CreateTextNode(eqop12.Text );
                XmlText at1Text = xDoc.CreateTextNode(atr12 .Text );
                XmlText st1Text = xDoc.CreateTextNode(string12.Text );
                nameAttr.AppendChild(nameText);
                veAttr.AppendChild(eqText);
                vaAttr.AppendChild(atText);
                vsAttr.AppendChild(stText);
                ve2Attr.AppendChild(eq1Text);
                va2Attr.AppendChild(at1Text);
                vs2Attr.AppendChild(st1Text);
                intElem.Attributes.Append(nameAttr);
                intElem.AppendChild(openElem );
                openElem.AppendChild(eqopElem);
                eqopElem.Attributes.Append(veAttr);
                eqopElem.AppendChild(atElem);
                eqopElem.AppendChild(stElem );
                atElem.Attributes.Append(vaAttr);
                stElem.Attributes.Append(vsAttr);
                intElem.AppendChild(closeElem );
                closeElem.AppendChild(eqop2Elem);
                eqop2Elem.Attributes.Append(ve2Attr);
                eqop2Elem.AppendChild(at2Elem);
                eqop2Elem.AppendChild(st2Elem);
                at2Elem.Attributes.Append(va2Attr);
                st2Elem.Attributes.Append(vs2Attr);
                xRoot.FirstChild.AppendChild(intElem);
                xDoc.Save(file);

            }
            if (name2.Text != "")
            {
                //работаем с событиями
                XmlElement eventElem = xDoc.CreateElement("Event");
                XmlElement formulaElem = xDoc.CreateElement("Formula");
                XmlElement eqopElem = xDoc.CreateElement("EqOp");
                XmlElement atrElem = xDoc.CreateElement("Attribute");
                XmlElement numberElem = xDoc.CreateElement("Number");
                XmlAttribute nameAttr = xDoc.CreateAttribute("Name");
                XmlAttribute eqopAttr = xDoc.CreateAttribute("Value");
                XmlAttribute atrAttr = xDoc.CreateAttribute("Value");
                XmlAttribute numAttr = xDoc.CreateAttribute("Value");
                XmlText nameText = xDoc.CreateTextNode(name2.Text);
                XmlText eqopText = xDoc.CreateTextNode(eqop2.Text);
                XmlText atrText = xDoc.CreateTextNode(atr2.Text);
                XmlText numText = xDoc.CreateTextNode(num.Text);
                nameAttr.AppendChild(nameText);
                eqopAttr.AppendChild(eqopText);
                atrAttr.AppendChild(atrText);
                numAttr.AppendChild(numText);
                eventElem.Attributes.Append(nameAttr);
                eventElem.AppendChild(formulaElem);
                formulaElem.AppendChild(eqopElem);
                eqopElem.Attributes.Append(eqopAttr);
                eqopElem.AppendChild(atrElem);
                eqopElem.AppendChild(numberElem);
                atrElem.Attributes.Append(atrAttr);
                numberElem.Attributes.Append(numAttr);
                xRoot.LastChild.AppendChild(eventElem);
                xDoc.Save(file);


            }
            name1.Text = name2.Text = eqop1.Text = eqop12.Text = eqop2.Text = atr1.Text = atr12.Text = atr2.Text = string1.Text = string12.Text = num.Text = "";
        }

        public void refresh()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            load();
        }

        public void create()
        {
            XmlTextWriter allen2 = new XmlTextWriter("Allen5.xml", null);
            allen2.WriteStartDocument();
            allen2.WriteStartElement("IntervalsAndEvents");
            allen2.WriteEndElement();
            allen2.Close();
            file = "Allen5.xml";
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(file);
            XmlElement xRoot = xDoc.DocumentElement;
            XmlElement ev = xDoc .CreateElement ("Events");
            XmlElement inter = xDoc .CreateElement ("Intervals");
            xRoot .AppendChild (inter);
            xRoot .AppendChild (ev);
            xDoc.Save(file);
        }
        
        public Form1()
        {
            InitializeComponent();
            
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            
            ToolTip t = new ToolTip(); 
            t.SetToolTip(comboBox1 ,"Интервалы");
            t.SetToolTip(comboBox2, "События");
            
            
            }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add();
            refresh();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete();
            refresh();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            lt1.Text = comboBox1.SelectedItem.ToString() ;
            foreach (intervals n in intervalslist)
            {
                for (int i = 0; i < intervalslist.Count; i++)
                {
                    if (comboBox1.SelectedItem.ToString() == intervalslist[i].name)
                    {
                        lt2.Text = "Начало\r\n" + intervalslist[i].EqOp + "\r\n\r\n" + "Конец\r\n" + intervalslist[i].EqOp2;
                        lt3.Text = intervalslist[i].string1 + "\r\n\r\n\r\n" + intervalslist[i].string12;
                        lt4.Text = intervalslist[i].Attribute + "\r\n" + intervalslist[i].Attribute2;
                    }
                }
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            lt1.Text = comboBox2.SelectedItem.ToString() ;
            foreach (events n in eventslist)
            {
                for (int i = 0; i < eventslist.Count; i++)
                {
                    if (comboBox2.SelectedItem.ToString() == eventslist[i].name)
                    {
                        lt2.Text = eventslist [i].EqOp ; 
                        lt3.Text = eventslist[i].info;
                        lt4.Text = eventslist[i].Attribute;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
           
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void загрузитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            openFileDialog1.ShowDialog();
            file = openFileDialog1.FileName;
            load();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void создатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            create();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            add();
            refresh();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            delete();
            refresh();
            
        }

       
    }

   
    public class events
    {
       public string name;
      public  string EqOp;
     public   string Attribute;
     public   string info;
        public events()
        { 
        name = "";
        EqOp = "";
        Attribute = "";
        info = ""; 
        }

    }

    public class intervals
    { 
       public string name;
       public int time;
       public int time2;
   public string EqOp;
   public string Attribute;
 public   string string1;
  public  string EqOp2;
   public string Attribute2;
   public string string12;
        public intervals()
        { 
        name = "";
        EqOp = "";
        Attribute = "";
        string1 = "";
            time =0 ;
        }
    }

}
