$(document).ready(() => {
    // Generate Menu
    const menuItems = [
        { name: "All Movies", link: "index.html" },
        { name: "Wishlist", link: "wishlist.html" },
        { name: "Cast Form", link: "cast.html" }
    ];

    menuItems.forEach(item => {
        $("#menu").append(`<li><a href="${item.link}">${item.name}</a></li>`);
    });

    // Render wishlist movies
    const renderWishlist = (movies) => {
        const $wishlistContainer = $("#wishlist-container");
        $wishlistContainer.empty(); // Clear previous content

        if (movies.length === 0) {
            $wishlistContainer.append("<p>No movies in your Wish List yet.</p>");
            return;
        }

        movies.forEach(movie => {
            $wishlistContainer.append(`
                <div class="movie">
                    <img src="${movie.photoUrl}" alt="${movie.title}" class="movie-img">
                    <div class="movie-details">
                        <h3>${movie.title}</h3>
                        <p><strong>Rating:</strong> ${movie.rating}</p>
                        <p><strong>Year:</strong> ${movie.year}</p>
                        <p><strong>Duration:</strong> ${movie.duration} mins</p>
                        <p><strong>Language:</strong> ${movie.language}</p>
                        <p><strong>Genre:</strong> ${movie.genre}</p>
                        <p>${movie.description}</p>
                    </div>
                </div>
            `);
        });
    };

    // Fetch wishlist movies from the server
    const fetchWishlist = () => {
        ajaxCall(
            "GET",
            "https://localhost:7171/api/Movie",
            null, // No data needed for GET request
            (movies) => {
                renderWishlist(movies);
                setupFilters(movies); // Setup filtering functionality
            },
            (error) => {
                console.error("Failed to load wishlist:", error);
                $("#wishlist-container").html("<p>Failed to load wishlist. Please try again later.</p>");
            }
        );
    };

    // Setup filters
    const setupFilters = (movies) => {
        // Filter by Rating
        $("#filter-rating-btn").on("click", () => {
            const minRating = parseFloat($("#rating-filter").val());
            if (!isNaN(minRating)) {
                const filteredMovies = movies.filter(movie => movie.rating >= minRating);
                renderWishlist(filteredMovies);
            }
        });

        // Filter by Duration
        $("#filter-duration-btn").on("click", () => {
            const maxDuration = parseInt($("#duration-filter").val(), 10);
            if (!isNaN(maxDuration)) {
                const filteredMovies = movies.filter(movie => movie.duration <= maxDuration);
                renderWishlist(filteredMovies);
            }
        });
    };

    // Load wishlist on page load
    fetchWishlist();
});

function ajaxCall(method, api, data, successCB, errorCB) {
    $.ajax({
        type: method,
        url: api,
        data: data,
        cache: false,
        contentType: "application/json",
        dataType: "json",
        success: successCB,
        error: errorCB
    });
}