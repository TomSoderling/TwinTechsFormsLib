using System;
using Xamarin.Forms;
using TwinTechs.Ios.Controls;
using Xamarin.Forms.Platform.iOS;
using TwinTechs.Ios.Extensions;
using TwinTechs.Extensions;
using UIKit;
using TwinTechs.Controls;
using System.Diagnostics;

[assembly: ExportRenderer(typeof(PageContainerView), typeof(PageContainerViewRenderer))]
namespace TwinTechs.Ios.Controls
{
	public class PageContainerViewRenderer : ViewRenderer<PageContainerView, ViewControllerContainer>
	{
		public PageContainerViewRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<PageContainerView> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.ViewController = null;
			}

			if (e.NewElement != null)
			{
				var viewControllerContainer = new ViewControllerContainer(Bounds);
				SetNativeControl(viewControllerContainer);
			}


		}

		void ChangePage(Page newPageToDisplay)
		{
			if (newPageToDisplay != null)
			{
				newPageToDisplay.Parent = Element.GetParentPage();

				//var pageRenderer = page.GetRenderer(); // old hacky way
				var pageRenderer = Platform.GetRenderer(newPageToDisplay); // TODO: this is always null. The new page hasn't been rendered yet.

				UIViewController viewController = null;
				if (pageRenderer != null && pageRenderer.ViewController != null)
					viewController = pageRenderer.ViewController;
				else
					viewController = newPageToDisplay.CreateViewController();
				
				var parentPage = Element.GetParentPage();
				//var renderer = parentPage.GetRenderer(); // old hacky way
				var parentPageRenderer = Platform.GetRenderer(parentPage);

				Control.ParentViewController = parentPageRenderer.ViewController;
				Control.ViewController = viewController;
			}
			else
			{
				if (Control != null)
				{
					Control.ViewController = null;
				}
			}
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			var page = Element != null ? Element.Content : null;
			if (page != null)
			{
				page.Layout(new Rectangle(0, 0, Bounds.Width, Bounds.Height));
			}
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			if (e.PropertyName == "Content" || e.PropertyName == "Renderer")
			{
				Device.BeginInvokeOnMainThread(() => ChangePage(Element != null ? Element.Content : null));
			}
		}

	}
}

