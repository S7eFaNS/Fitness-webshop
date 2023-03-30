using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Database.DataBase
{
    public static class Helpers
    {
        public static T Serialize<T>(SqlDataReader reader) where T : new()
        {
            T record = new();
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                ColumnName? attribute = property.GetCustomAttribute<ColumnName>();
                if (attribute == null)
                    throw new Exception($"Object if type {typeof(T).Name} cannot be serialized. Property {property.Name} was not correctly annotated.");
                string columnName = attribute.Name;
                var readedValue = reader[columnName];
                if (readedValue != DBNull.Value)
                {
                    object? value = null;
                    if (property.PropertyType.BaseType == typeof(Enum))
                        value = Enum.Parse(property.PropertyType, (string)readedValue);
                    else
                        value = Convert.ChangeType(readedValue, property.PropertyType);
                    property.SetValue(record, value);
                }
            }
            return record;
        }

        public static string ConvertPascalToSnake(string pascalCaseString)
        {
            if (string.IsNullOrEmpty(pascalCaseString)) return pascalCaseString;
            StringBuilder snakeCaseBuilder = new StringBuilder();
            for (int i = 0; i < pascalCaseString.Length; i++)
            {
                char currentChar = pascalCaseString[i];
                if (char.IsUpper(currentChar) && i > 0) snakeCaseBuilder.Append("_");
                snakeCaseBuilder.Append(char.ToLower(currentChar));
            }
            return snakeCaseBuilder.ToString();
        }

        public static TViewModel MapToModel<TEntity, TViewModel>(TEntity entity) where TViewModel : new()
        {
            var viewModel = new TViewModel();
            var entityType = entity.GetType();
            foreach (PropertyInfo viewModelProp in typeof(TViewModel).GetProperties())
            {
                PropertyInfo? entityProp = entityType.GetProperty(viewModelProp.Name);
                if (entityProp == null) continue;
                viewModelProp.SetValue(viewModel, entityProp.GetValue(entity));
            }
            return viewModel;
        }

        public static TEntity MapToEntity<TViewModel, TEntity>(TViewModel viewModel) where TEntity : Entity, new()
        {
            var entity = Activator.CreateInstance<TEntity>();
            var entityType = entity.GetType();
            foreach (PropertyInfo viewModelProp in typeof(TViewModel).GetProperties())
            {
                PropertyInfo? entityProp = entityType.GetProperty(viewModelProp.Name);
                if (entityProp != null && entityProp.PropertyType == viewModelProp.PropertyType)
                {
                    var val = viewModelProp.GetValue(viewModel, null);
                    entityProp.SetValue(entity, val);
                }

            }
            return entity;
        }

        public static string GetColumnName(PropertyInfo prop)
        {
            var attribute = prop.GetCustomAttribute<ColumnName>();
            if (attribute == null)
            {
                attribute = prop.GetCustomAttribute<PrimaryKey>();
                if (attribute == null)
                    throw new Exception("Cannot get attribute name of given column");
            }
            return attribute.Name;
        }
    }
}
