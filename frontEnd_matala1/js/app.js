// Generate Menu
$(document).ready(() => {
    const menuItems = [
        { name: "Home", link: "index.html" },
        { name: "Wish List", link: "wishlist.html" },
        { name: "Cast Form", link: "cast.html" }

    ];

    menuItems.forEach(item => {
        $("#menu").append(
            `<li><a href="${item.link}">${item.name}</a></li>`
        );
    });

    // Render movies
    const renderMovies = (movies) => {
        const $moviesContainer = $("#movies-container");
        $moviesContainer.empty(); // Clear previous content

        movies.forEach(movie => {
            $moviesContainer.append(`
                <div class="movie">
                    <img src="${movie.photoUrl}" alt="${movie.title}" class="movie-img">
                    <h3>${movie.title}</h3>
                    <p><strong>Rating:</strong> ${movie.rating}</p>
                    <p><strong>Release Year:</strong> ${movie.releaseYear}</p>
                    <p><strong>Duration:</strong> ${movie.duration} minutes</p>
                    <p><strong>Language:</strong> ${movie.language}</p>
                    <p>${movie.description}</p>
                    <p><strong>Genre:</strong> ${movie.genre}</p>
                    <button class="wishlist-btn" data-id="${movie.id}">Add to Wish List</button>
                </div>
            `);
        });

        // Add event listeners to "Add to Wish List" buttons
        $(".wishlist-btn").on("click", function () {
            const movieId = $(this).data("id");
            const selectedMovie = movies.find(m => m.id == movieId);
console.log(selectedMovie);
            if (selectedMovie) {
                ajaxCall(
                    "POST",
                    "https://localhost:7171/api/Movie",
                    JSON.stringify(selectedMovie),
                    () => alert("Movie added to Wish List!"),
                    (error) => console.error("Error adding movie to Wish List:", error)
                );
            }
        });
    };

    // Fetch movies from local array
    if (typeof items !== "undefined") {
        renderMovies(items);
    } else {
        console.error("Error: 'items' is not defined .");
    }
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