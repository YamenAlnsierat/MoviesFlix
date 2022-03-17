function MovieItem({movie}){
    return(
        <article>
            <div>
                {movie.title}
            </div>
            <div>
                {movie.genre}
            </div>
        </article>
    )
}

export default MovieItem;