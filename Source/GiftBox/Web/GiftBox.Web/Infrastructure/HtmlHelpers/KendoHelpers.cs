namespace GiftBox.Web.Infrastructure.HtmlHelpers
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.UI.Fluent;

    public static class KendoHelpers
    {
        public static GridBuilder<T> FullFeaturedGrid<T>(this HtmlHelper helper, string gridName,
            string readControllerName, string controllerName, Expression<Func<T, int>> modelIdExpression,
            string readMethod, string createMethod, string updateMethod, string destroyMethod,
            Action<GridColumnFactory<T>> columns = null) where T : class
        {
            if (columns == null)
            {
                columns = cols =>
                {
                    cols.AutoGenerate(true);
                    cols.Command(command =>
                    {
                        command.Edit();
                        command.Destroy();
                    }).Width(150);
                };
            }

            return helper.Kendo()
                .Grid<T>()
                .Name(gridName)
                .Columns(columns)
                .ColumnMenu()
                .Pageable(page => page.Refresh(true))
                .Sortable()
                .Groupable()
                .Filterable()
                .Editable(edit => edit.Mode(GridEditMode.PopUp))
                .ToolBar(toolbar => toolbar.Create())
                .DataSource(data =>
                    data
                        .Ajax()
                        .PageSize(5)
                        .Model(m => m.Id(modelIdExpression))
                        .Read(read => read.Action(readMethod, readControllerName))
                        .Create(create => create.Action(createMethod, controllerName))
                        .Update(update => update.Action(updateMethod, controllerName))
                        .Destroy(destroy => destroy.Action(destroyMethod, controllerName)));
        }
    }
}