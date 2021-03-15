using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertirDataTableDesdeHtml
{
    public class HtmlToDatatable
    {
        public static DataTable GetHtmlDataTable(string url, string tablename)
        {
            return GetDataTable(url, tablename);
        }

        public static DataTable GetHtmlDataTable(Uri uri, string tablename)
        {
            return GetDataTable(uri, tablename);
        }

        private static string ReadHtml(string url)
        {
            System.Net.WebClient client = new System.Net.WebClient();
            return client.DownloadString(url);
        }

        private static HtmlDocument GetHtmlDocument(string url)
        {
            string htmlText = ReadHtml(url);
            if (string.IsNullOrWhiteSpace(htmlText)) throw new Exception("No se ha leido texto html.");
            using (WebBrowser browser = new WebBrowser())
            {
                browser.DocumentText = htmlText;
                do
                {
                    Application.DoEvents();
                } while (browser.ReadyState != WebBrowserReadyState.Complete);
                return browser.Document;
            }
        }

        private static HtmlElement GetHtmlTable(HtmlDocument doc, string tablename)
        {
            return doc.GetElementById(tablename);
        }
        private static DataTable GetDataTable(string url, string tablename)
        {
            DataTable dt = new DataTable();
            HtmlDocument doc = GetHtmlDocument(url);
            if (doc == null) throw new Exception("No se ha obtenido el documento HTML.");
            HtmlElement table = GetHtmlTable(doc, tablename);
            if (table == null) throw new Exception("No se ha obtenido la tabla indicada.");
            CreateColumns(table, dt);
            CreateRows(table, dt);
            return dt;
        }

        private static DataTable GetDataTable(Uri uri, string tablename)
        {
            DataTable dt = new DataTable();
            HtmlDocument doc = GetHtmlDocument(uri);
            if (doc == null) throw new Exception("No se ha obtenido el documento HTML.");
            HtmlElement table = GetHtmlTable(doc, tablename);
            if (table == null) throw new Exception("No se ha obtenido la tabla indicada.");
            CreateColumns(table, dt);
            CreateRows(table, dt);
            return dt;
        }

        private static HtmlDocument GetHtmlDocument(Uri uri)
        {
            string htmlText = File.ReadAllText(uri.LocalPath);
            if (string.IsNullOrWhiteSpace(htmlText)) throw new Exception("No se ha leido texto html.");
            using (WebBrowser browser = new WebBrowser())
            {
                browser.DocumentText = htmlText;
                do
                {
                    Application.DoEvents();
                } while (browser.ReadyState != WebBrowserReadyState.Complete);
                return browser.Document;
            }
        }

        private static void CreateRows(HtmlElement table, DataTable dt)
        {
            List<HtmlElement> rowCol = table.GetByTagName("TR").ToList();
            DataRow row;
            foreach (HtmlElement fila in rowCol)
            {
                if (fila.Parent.TagName != "THEAD")
                {
                    row = dt.NewRow();
                    List<HtmlElement> tdCol = fila.GetByTagName("TD").ToList();

                    for (int counter = 0; counter <= dt.Columns.Count - 1; counter++)
                        row[counter] = tdCol[counter].InnerText;

                    dt.Rows.Add(row);
                }
            }
        }
        private static void CreateColumns(HtmlElement table, DataTable dt)
        {
            HtmlElement header = table.GetByTagName("THEAD").FirstOrDefault();
            HtmlElement firstRow = table.GetByTagName("TR").FirstOrDefault();
            if (header == null)
            {
                CreateHeaders(dt, firstRow);
            }
            else
            {
                CreateHeaders(dt, header);
            }
        }

        private static void CreateHeaders(DataTable dt, HtmlElement headerElement)
        {
            foreach (HtmlElement element in headerElement.All)
            {
                dt.Columns.Add(element.InnerText);
            }
        }
    }
}
