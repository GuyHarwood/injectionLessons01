namespace SOLID.No
{
	public class AreaCalculator1
	{
		public double Area(Rectangle[] shapes)
		{
			double area = 0;
			foreach (var shape in shapes)
			{
				area += shape.Width*shape.Height;
			}

			return area;
		}
	}
}