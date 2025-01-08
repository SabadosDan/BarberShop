using WebAPI.Models;

namespace Mobile;

public partial class BarberRatingPage : ContentPage
{
    private int BarberId;

    private int rating = 0;
    public BarberRatingPage(int barberId)
	{
		InitializeComponent();
        this.BarberId = barberId;
	}

    private void OnStarClicked(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        int starIndex = int.Parse(button.ClassId); 

        rating = starIndex;
        UpdateStars(); 
    }

    private void UpdateStars()
    {
        Star1.Source = rating >= 1 ? "star_filled.png" : "star_empty.png";
        Star2.Source = rating >= 2 ? "star_filled.png" : "star_empty.png";
        Star3.Source = rating >= 3 ? "star_filled.png" : "star_empty.png";
        Star4.Source = rating >= 4 ? "star_filled.png" : "star_empty.png";
        Star5.Source = rating >= 5 ? "star_filled.png" : "star_empty.png";
    }


    private async void OnPostReviewClicked(object sender, EventArgs e)
    {
        if (rating == 0 || string.IsNullOrWhiteSpace(ReviewText.Text))
        {
            await DisplayAlert("Eroare", "Te rugăm să oferi un rating și să scrii o recenzie.", "OK");
            return;
        }



        var review = new Review
        {
            BarberId = BarberId,
            Rating = rating,
            Comment = ReviewText.Text,  
            CreatedAt = DateTime.UtcNow  
        };

        var reviewService = new ReviewService(new HttpClient()); 
        await reviewService.PostReviewAsync(review);

        await DisplayAlert("Succes", "Recenzia ta a fost trimisă.", "OK");

        ReviewText.Text = string.Empty;
        rating = 0;
        UpdateStars();
    }

    private async void OnSubmitFeedbackClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Success", "Thank you for your feedback!", "OK");
    }

}