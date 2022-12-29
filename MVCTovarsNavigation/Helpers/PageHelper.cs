using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MVCTovarsNavigation.Models;

namespace MVCTovarsNavigation.Helpers
{
    public static class PageHelper
    {
        public static MvcHtmlString DisplayList4(this HtmlHelper html, IndexViewModel indexViewModel)
        {
            if (indexViewModel.PageInfo == null)
            {
                indexViewModel.PageInfo = new PageInfo { PageNumber = 0, PageSize = 3, TotalItems = 5 };
            }
            TagBuilder Table = new TagBuilder("table");
            Table.Attributes.Add("border", "1");
            Table.Attributes.Add("cellspacing", "0.8");
            Table.Attributes.Add("width", "60%");

            TagBuilder tr = new TagBuilder("tr");

            TagBuilder th = new TagBuilder("th");
            th.Attributes.Add("align", "center");
            th.SetInnerText("Назва");
            TagBuilder th1 = new TagBuilder("th");
            th1.Attributes.Add("align", "center");
            th1.SetInnerText("Ціна");
            TagBuilder th2 = new TagBuilder("th");
            th2.Attributes.Add("align", "center");
            th2.SetInnerText("Кількість");
            TagBuilder th3 = new TagBuilder("th");
            th3.Attributes.Add("align", "center");
            th3.SetInnerText("Опис");

            TagBuilder thh = new TagBuilder("th");
            thh.Attributes.Add("align", "center");
            thh.SetInnerText("Виробник");
            TagBuilder thh1 = new TagBuilder("th");
            thh1.Attributes.Add("align", "center");
            thh1.SetInnerText("Країна виробника");

            TagBuilder th4 = new TagBuilder("th");
            th4.Attributes.Add("align", "center");
            th4.SetInnerText("Операції");
            th4.Attributes.Add("colspan", "3");

            tr.InnerHtml += th;
            tr.InnerHtml += th1;
            tr.InnerHtml += th2;
            tr.InnerHtml += th3;
            tr.InnerHtml += thh;
            tr.InnerHtml += thh1;
            tr.InnerHtml += th4;

            Table.InnerHtml += tr;

            for (int i = 0; i < (indexViewModel.PageInfo.PageNumber + indexViewModel.PageInfo.PageSize) && i < indexViewModel.Tovars.Count; i++)
            {
                TagBuilder trT = new TagBuilder("tr");

                TagBuilder td = new TagBuilder("td");
                td.SetInnerText(indexViewModel.Tovars[i].Name);
                td.Attributes.Add("align", "center");
                trT.InnerHtml += td;

                TagBuilder td1 = new TagBuilder("td");
                td1.Attributes.Add("align", "center");
                td1.SetInnerText(indexViewModel.Tovars[i].Prize.ToString());
                trT.InnerHtml += td1;

                TagBuilder td2 = new TagBuilder("td");
                td2.Attributes.Add("align", "center");
                td2.SetInnerText(indexViewModel.Tovars[i].Quantity.ToString());
                trT.InnerHtml += td2;

                TagBuilder td3 = new TagBuilder("td");
                td3.Attributes.Add("align", "center");
                td3.SetInnerText(indexViewModel.Tovars[i].Desc);
                trT.InnerHtml += td3;

                TagBuilder tdd = new TagBuilder("td");
                tdd.Attributes.Add("align", "center");
                tdd.SetInnerText(indexViewModel.Tovars[i].Producer.ProducerName);
                trT.InnerHtml += tdd;

                TagBuilder tdd1 = new TagBuilder("td");
                tdd1.Attributes.Add("align", "center");
                tdd1.SetInnerText(indexViewModel.Tovars[i].Country.CountryName);
                trT.InnerHtml += tdd1;

                TagBuilder td4 = new TagBuilder("td");
                td4.Attributes.Add("align", "center");
                TagBuilder aChoose = new TagBuilder("a");
                aChoose.Attributes.Add("href", "/Admin/Choose/" + indexViewModel.Tovars[i].ID);
                aChoose.SetInnerText("Вибрати");
                aChoose.AddCssClass("btn btn-primary");
                td4.InnerHtml += aChoose;
                trT.InnerHtml += td4;

                TagBuilder td5 = new TagBuilder("td");
                td5.Attributes.Add("align", "center");
                TagBuilder aEdit = new TagBuilder("a");
                aEdit.Attributes.Add("href", "/Admin/Edit/" + indexViewModel.Tovars[i].ID);
                aEdit.SetInnerText("Редагувати");
                aEdit.AddCssClass("btn btn-primary");
                td5.InnerHtml += aEdit;
                trT.InnerHtml += td5;

                TagBuilder td6 = new TagBuilder("td");
                td6.Attributes.Add("align", "center");
                TagBuilder aDelete = new TagBuilder("a");
                aDelete.Attributes.Add("href", "/Admin/Delete/" + indexViewModel.Tovars[i].ID);
                aDelete.AddCssClass("btn btn-primary");
                aDelete.SetInnerText("Видалити");
                td6.InnerHtml += aDelete;
                trT.InnerHtml += td6;

                Table.InnerHtml += trT;
            }
            return new MvcHtmlString(Table.ToString());
        }
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PageInfo pageInfo, Func<int, string> page_url)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", page_url(i));
                tag.InnerHtml = i.ToString();

                tag.AddCssClass("btn");

                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }

                sb.Append(tag.ToString());
            }
            return MvcHtmlString.Create(sb.ToString());
        }
    }
}