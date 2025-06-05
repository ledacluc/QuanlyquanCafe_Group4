using System;
namespace Quanlyquancafe.DAO
{
	public class FoodDAO
	{
		private static FoodDAO instance;

		public static FoodDAO Instance
		{
			get if (instance == null) { instance = new FoodDAO(); return FoodDAO.instance; }
			private set { FoodDAO.instance = value; }
		}
             private FoodDAO() { }

		     public List<Food> GetFoodByCategoryID (int id)
			{
				List<Food> List = new List<Food> ();
				string query = " Select * from Food where idCategory = " + id;
				DataTable data = DataProvider.Instance.ExecuteQuery(query);
				foreach (DataRow item in data.Rows)
				{
					FoodDAO food = new Food (item);
					List.Add (food);
				} 
				return List;
			 }
			public List<Food> GetListFood()
			{
				List<Food> List = new List<Food>();
				string query = " Select * from Food ";
				DataTable data = DataProvider.Instance.ExecuteQuery(query);
			    foreach (DataRow item in data.Rows)
			{
                FoodDAO food = new Food(item);
                List.Add(food);
            }	
				return List;
        }
	}
}     
