namespace GiftBox.Web.Infrastructure.HtmlHelpers
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.UI.Fluent;

    public static class KendoHelpers
    {
        public static GridBuilder<T> FullFeaturedGrid<T>(
            this HtmlHelper helper, 
            string gridName,
            string readControllerName,
            string controllerName,
            string readMethod, 
            string createMethod, 
            string updateMethod,
            string destroyMethod,
            Action<DataSourceModelDescriptorFactory<T>> factory,
            Action<GridColumnFactory<T>> columns = null) 
            where T : class
        {
            if (columns == null)
            {
                columns = cols =>
                {
                    cols.AutoGenerate(true);
                    cols.Command(command =>
                    {
                        command.Destroy();
                    }).Width(120);
                };
            }

            return helper.Kendo()
                .Grid<T>()
                .Name(gridName)
                .Columns(columns)
                .ToolBar(toolbar =>
                {
                    toolbar.Create();
                    toolbar.Save();
                })
                .Editable(editable => editable.Mode(GridEditMode.InCell))
                .Pageable()
                .Sortable()
                .Scrollable() 
                .DataSource(dataSource => dataSource
                    .Ajax()
                    .Batch(true)
                    .ServerOperation(false)
                    .PageSize(5)
                    .Model(factory)
                    .Read(read => read.Action(readMethod, readControllerName))
                    .Create(create => create.Action(createMethod, controllerName))
                    .Update(update => update.Action(updateMethod, controllerName))
                    .Destroy(destroy => destroy.Action(destroyMethod, controllerName)));
        }
    }
}