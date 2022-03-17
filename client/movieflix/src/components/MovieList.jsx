import { useEffect, useState } from "react";
import MovieItem from "./MovieItem";

function MovieList(){

    const [movies, setMovies] = useState([])

    useEffect(() => {
        console.log("useEffect")
        listMovies();
    }, []);

    const listMovies = async() => {
        const url = "https://localhost:7134/api/v1/movies";

        try {
            const response = await fetch(url, {method:'GET',});

            if(!response.status === 200){
                console.log('det gick inte att hamta');
                return
            }
            const result = await response.json();
            console.log(result);
            setMovies(result)
        }
        catch(error)
        {   
            console.log(error);
        }
    } 

    return(
        <section>
            <h2>Here list all movies.</h2>
            {movies.map((movie) => (
            <MovieItem key={movie.id} movie={movie} />
            ))}
        </section>
    )
}

export default MovieList;