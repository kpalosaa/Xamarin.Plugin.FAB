using System;
using System.ComponentModel;
using Xamarin.Forms.Platform.UWP;
using Windows.UI.Xaml;
using Xamarin.Forms;
using FAB.Forms;

[assembly: ExportRenderer(typeof(FAB.Forms.FloatingActionButton), typeof(FAB.UWP.FloatingActionButtonRenderer))]

namespace FAB.UWP
{
	public partial class FloatingActionButtonRenderer : ViewRenderer<FloatingActionButton, Windows.UI.Xaml.Controls.Button>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<FloatingActionButton> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement == null)
				return;

			if (this.Control == null)
			{
				Windows.UI.Xaml.Controls.Button control = new Windows.UI.Xaml.Controls.Button();

				control.Style = GetStyle();

				control.Click += OnButtonClick;
				this.SetNativeControl(control);

				this.UpdateStyles();
			}
		}

		private Windows.UI.Xaml.Style GetStyle()
		{
			string dataTemplateXaml = 
				@"<Style 
					xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
					xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"" TargetType=""Button"">
					<Setter Property=""Background"" Value=""{ThemeResource SystemControlBackgroundBaseLowBrush}""/>
					<Setter Property=""Foreground"" Value=""{ThemeResource SystemControlForegroundBaseHighBrush}""/>
					<Setter Property=""BorderBrush"" Value=""{ThemeResource SystemControlForegroundTransparentBrush}""/>
					<Setter Property=""BorderThickness"" Value=""{ThemeResource ButtonBorderThemeThickness}""/>
					<Setter Property=""Padding"" Value=""8,4,8,4""/>
					<Setter Property=""HorizontalAlignment"" Value=""Left""/>
					<Setter Property=""VerticalAlignment"" Value=""Center""/>
					<Setter Property=""FontFamily"" Value=""{ThemeResource ContentControlThemeFontFamily}""/>
					<Setter Property=""FontWeight"" Value=""Normal""/>
					<Setter Property=""FontSize"" Value=""{ThemeResource ControlContentThemeFontSize}""/>
					<Setter Property=""UseSystemFocusVisuals"" Value=""True""/>
					<Setter Property=""Template"">
						<Setter.Value>
							<ControlTemplate TargetType=""Button"">
								<Grid x:Name=""RootGrid"">
									<VisualStateManager.VisualStateGroups>
										<VisualStateGroup x:Name=""CommonStates"">
											<VisualState x:Name=""Normal"">
												<Storyboard>
													<PointerUpThemeAnimation Storyboard.TargetName=""RootGrid""/>
												</Storyboard>
											</VisualState>
											<VisualState x:Name=""PointerOver"">
												<Storyboard>
													<!--<ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=""Fill"" Storyboard.TargetName=""BorderCircle"">
														<DiscreteObjectKeyFrame KeyTime=""0"" Value=""{ThemeResource SystemControlHighlightBaseMediumLowBrush}""/>
													</ObjectAnimationUsingKeyFrames>-->
													<ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=""Foreground"" Storyboard.TargetName=""ContentPresenter"">
														<DiscreteObjectKeyFrame KeyTime=""0"" Value=""{ThemeResource SystemControlHighlightBaseHighBrush}""/>
													</ObjectAnimationUsingKeyFrames>
													<PointerUpThemeAnimation Storyboard.TargetName=""RootGrid""/>
												</Storyboard>
											</VisualState>
											<VisualState x:Name=""Pressed"">
												<Storyboard>
													<!--<ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=""Fill"" Storyboard.TargetName=""BorderCircle"">
														<DiscreteObjectKeyFrame KeyTime=""0"" Value=""{ThemeResource SystemControlBackgroundBaseMediumLowBrush}""/>
													</ObjectAnimationUsingKeyFrames>-->
													<ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=""Foreground"" Storyboard.TargetName=""ContentPresenter"">
														<DiscreteObjectKeyFrame KeyTime=""0"" Value=""{ThemeResource SystemControlHighlightBaseHighBrush}""/>
													</ObjectAnimationUsingKeyFrames>
													<PointerDownThemeAnimation Storyboard.TargetName=""RootGrid""/>
												</Storyboard>
											</VisualState>
											<VisualState x:Name=""Disabled"">
												<Storyboard>
													<ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=""Fill"" Storyboard.TargetName=""BorderCircle"">
														<DiscreteObjectKeyFrame KeyTime=""0"" Value=""{ThemeResource SystemControlBackgroundBaseLowBrush}""/>
													</ObjectAnimationUsingKeyFrames>
													<ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=""Foreground"" Storyboard.TargetName=""ContentPresenter"">
														<DiscreteObjectKeyFrame KeyTime=""0"" Value=""{ThemeResource SystemControlDisabledBaseMediumLowBrush}""/>
													</ObjectAnimationUsingKeyFrames>
													<ObjectAnimationUsingKeyFrames Storyboard.TargetProperty=""Stroke"" Storyboard.TargetName=""BorderCircle"">
														<DiscreteObjectKeyFrame KeyTime=""0"" Value=""{ThemeResource SystemControlDisabledTransparentBrush}""/>
													</ObjectAnimationUsingKeyFrames>
												</Storyboard>
											</VisualState>
										</VisualStateGroup>
									</VisualStateManager.VisualStateGroups>
									<Ellipse x:Name=""BorderCircle"" Stroke=""{TemplateBinding BorderBrush}"" Fill=""{TemplateBinding Foreground}"" StrokeThickness=""4""/>
									<!--<Ellipse x:Name=""ForegroundCircle"" Fill=""{TemplateBinding Foreground}"" Margin=""3""/>-->
									<ContentPresenter x:Name=""ContentPresenter"" VerticalAlignment=""Center"" AutomationProperties.AccessibilityView=""Raw"" ContentTemplate=""{TemplateBinding ContentTemplate}"" ContentTransitions=""{TemplateBinding ContentTransitions}"" Content=""{TemplateBinding Content}"" HorizontalContentAlignment=""{TemplateBinding HorizontalContentAlignment}"" Padding=""{TemplateBinding Padding}"" VerticalContentAlignment=""{TemplateBinding VerticalContentAlignment}""/>
								</Grid>
							</ControlTemplate>
						</Setter.Value>
					</Setter>
				</Style>";

			return (Windows.UI.Xaml.Style)Windows.UI.Xaml.Markup.XamlReader.Load(dataTemplateXaml);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == FloatingActionButton.SourceProperty.PropertyName)
			{
				this.SetSize();
			}
			else if (e.PropertyName == FloatingActionButton.NormalColorProperty.PropertyName ||
					 e.PropertyName == FloatingActionButton.PressedColorProperty.PropertyName ||
					 e.PropertyName == FloatingActionButton.DisabledColorProperty.PropertyName)
			{
				this.SetBackgroundColors();
			}
			else if (e.PropertyName == FloatingActionButton.HasShadowProperty.PropertyName)
			{
				
			}
			else if (e.PropertyName == FloatingActionButton.SourceProperty.PropertyName ||
					 e.PropertyName == FloatingActionButton.WidthProperty.PropertyName ||
					 e.PropertyName == FloatingActionButton.HeightProperty.PropertyName)
			{
				this.SetImage();
			}
			else if (e.PropertyName == FloatingActionButton.IsEnabledProperty.PropertyName)
			{
				this.UpdateEnabled();
			}
			else
			{
				base.OnElementPropertyChanged(sender, e);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.Control.Click -= OnButtonClick;
			}

			base.Dispose(disposing);
		}

		public override SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint)
		{
			double value = this.Element.Size == FAB.Forms.FabSize.Normal ? 56 : 40;

			return new SizeRequest(new Size(value, value));
		}

		private void UpdateStyles()
		{
			this.SetSize();

			this.SetBackgroundColors();

			this.SetImage();

			this.UpdateEnabled();
		}

		private void SetSize()
		{
			switch (this.Element.Size)
			{
				case FAB.Forms.FabSize.Mini:
					this.Control.Width = 40;
					this.Control.Height = 40;
					//this.Control.BorderRadius = 40 / 2;
					break;
				case FAB.Forms.FabSize.Normal:
					this.Control.Width = 56;
					this.Control.Height = 56;
					//this.Control.BorderRadius = 56 / 2;
					break;
			}
		}

		private void SetBackgroundColors()
		{
			//this.Control.BackgroundColor = ConvertExtensions.ToBrush(this.Element.NormalColor);
			this.Control.Foreground = ConvertExtensions.ToBrush(this.Element.NormalColor);
		}

		private void SetImage()
		{
			SetImageAsync(this.Element.Source);
		}

		private void UpdateEnabled()
		{
			this.Control.IsEnabled = this.Element.IsEnabled;
		}

		private void OnButtonClick(object sender, RoutedEventArgs e)
		{
			this.Element.SendClicked();
		}

		private async void SetImageAsync(ImageSource source)
		{
			if (source != null)
			{
				var handler = GetHandler(source);
				var imageSource = await handler.LoadImageAsync(source);
				if (imageSource != null)
				{
					Windows.UI.Xaml.Controls.Image image = new Windows.UI.Xaml.Controls.Image();
					image.Source = imageSource;

					this.Control.Content = image;
				}
			}
		}
	}

	internal static class ConvertExtensions
	{
		public static Windows.UI.Xaml.Media.Brush ToBrush(this Xamarin.Forms.Color color)
		{
			return new Windows.UI.Xaml.Media.SolidColorBrush(ConvertExtensions.ToWindowsColor(color));
		}

		public static Windows.UI.Color ToWindowsColor(this Xamarin.Forms.Color color)
		{
			return Windows.UI.Color.FromArgb((byte)(color.A * (double)byte.MaxValue), (byte)(color.R * (double)byte.MaxValue), (byte)(color.G * (double)byte.MaxValue), (byte)(color.B * (double)byte.MaxValue));
		}
	}
}
