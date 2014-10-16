using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace AJWGAP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(Server.MapPath("~/employees.data.xml"));
                grdView.DataSource = dataSet;
                grdView.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath("~/employees.data.xml"));
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(Server.MapPath("~/employees.data.xml"));
            int startValue = 1450 + dataSet.Tables[0].Rows.Count;
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                XmlElement parentelement = xmldoc.CreateElement("employee");

                XmlElement empid = xmldoc.CreateElement("EmployeeId");
                XmlElement name = xmldoc.CreateElement("ReportsTo");
                XmlElement designation = xmldoc.CreateElement("Name");
                XmlElement city = xmldoc.CreateElement("Job");
                XmlElement country = xmldoc.CreateElement("Phone");
                XmlElement email = xmldoc.CreateElement("Email");
                XmlElement orgUnit = xmldoc.CreateElement("OrgUnit");
                XmlElement salary = xmldoc.CreateElement("Salary");
                XmlElement gender = xmldoc.CreateElement("Gender");
                XmlElement maritalStatus = xmldoc.CreateElement("MaritalStatus");
                XmlElement employeeType = xmldoc.CreateElement("EmployeeType");
                XmlElement employeeStatus = xmldoc.CreateElement("EmployeeStatus");
                empid.InnerText = startValue.ToString();
                name.InnerText = dataRow[1].ToString();
                designation.InnerText = dataRow[2].ToString();
                city.InnerText = dataRow[3].ToString();
                country.InnerText = dataRow[4].ToString();
                orgUnit.InnerText = dataRow[5].ToString();
                salary.InnerText = dataRow[6].ToString();
                gender.InnerText = dataRow[7].ToString();
                maritalStatus.InnerText = dataRow[8].ToString();
                employeeType.InnerText = dataRow[9].ToString();
                employeeStatus.InnerText = dataRow[10].ToString();
                parentelement.AppendChild(empid);
                parentelement.AppendChild(name);
                parentelement.AppendChild(designation);
                parentelement.AppendChild(city);
                parentelement.AppendChild(country);
                parentelement.AppendChild(orgUnit);
                parentelement.AppendChild(salary);
                parentelement.AppendChild(gender);
                parentelement.AppendChild(maritalStatus);
                parentelement.AppendChild(employeeType);
                parentelement.AppendChild(employeeStatus);

                xmldoc.DocumentElement.AppendChild(parentelement);
                startValue++;
            }
            xmldoc.Save(Server.MapPath("~/employees.data.xml"));
        }

        protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdView.PageIndex = e.NewPageIndex;
        }
    }
}