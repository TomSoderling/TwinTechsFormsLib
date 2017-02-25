using System;
using Xamarin.Forms;

namespace TwinTechs.Controls
{
	//specialized class for showing a page within a page
	public class PageContainerView : View
	{
		public PageContainerView() { }

		public static readonly BindableProperty ContentProperty = BindableProperty.Create<PageContainerView, Page>(s => s.Content, null);

		public Page Content
		{
			get { return (Page)GetValue(ContentProperty); }
			set { SetValue(ContentProperty, value); }
		}
	}
}

