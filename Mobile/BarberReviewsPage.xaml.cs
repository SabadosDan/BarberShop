namespace Mobile;

public partial class BarberReviewsPage : ContentPage
{
    private readonly ReviewService _reviewService;
    public BarberReviewsPage(int barberId)
	{
		InitializeComponent();

        _reviewService = new ReviewService(new HttpClient());
        LoadReviews(barberId);
    }

    private async void LoadReviews(int barberId)
    {
        var reviews = await _reviewService.GetReviewsByBarberIdAsync(barberId);

        if (reviews == null || reviews.Count == 0)
        {
            NoReviewsLabel.IsVisible = true;
            ReviewsListView.IsVisible = false;
        }
        else
        {
            NoReviewsLabel.IsVisible = false;
            ReviewsListView.IsVisible = true;
            ReviewsListView.ItemsSource = reviews;
        }
    }
}