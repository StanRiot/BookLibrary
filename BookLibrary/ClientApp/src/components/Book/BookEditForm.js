import React, { Component } from 'react'
import { Link, Redirect } from "react-router-dom"

export class BookEditForm extends Component {
    constructor(props) {
        super(props);
        console.log(this.props.location);
        this.state =
        {
            id: this.props.location.props.book.id,
            name: this.props.location.props.book.name,
            year: this.props.location.props.book.year,
            authors: this.props.location.props.book.authors,
            genres: this.props.location.props.book.genres,
            submitted: false,

            nameValid: true,
            yearValid: true,
            authorsValid: this.props.location.props.book.authors.length > 0,
            genresValid: this.props.location.props.book.genres.length > 0,

            formIsValid: () => {
                return this.state.nameValid &&
                    this.state.yearValid &&
                    this.state.authorsValid &&
                    this.state.genresValid;
            },
            availableAuthors: [],
            availableGenres: []
        };

    }

    async componentDidMount() {

        const authorResponse = await fetch('/api/author/list');
        const authorData = await authorResponse.json();
        authorData.forEach((e) => e.selected = false);
        this.setState({ availableAuthors: authorData, loading: false });

        const genreResponse = await fetch('/api/genre/list');
        const genreData = await genreResponse.json();
        genreData.forEach((e) => e.selected = false);
        this.setState({ availableGenres: genreData, loading: false });
    }

    nameChangeHandler = (data) => {
        this.setState(
            {
                name: data.target.value,
                nameValid: data.target.value != null && data.target.value.length > 0,
            }
        );
    }
    yearChangeHandler = (data) => {
        this.setState(
            {
                year: data.target.value,
                yearValid: data.target.value != null && data.target.value.length > 0 && data.target.value.match(/^-{0,1}\d+$/)
            }
        );
    }
    authorsCheckedHandler = (data) => {
        if (data.target.checked) {
            this.state.authors.push(data.target.value);
        } else {
            for (let i = 0; i < this.state.authors.length; ++i) {
                if (this.state.authors[i] === data.target.value) {
                    this.state.authors.splice(i, 1);
                }
            }
        }

        this.setState(
            {
                authorsValid: this.state.authors.length > 0
            });


    }
    genresCheckedHandler = (data) => {
        if (data.target.checked) {
            this.state.genres.push(data.target.value);
        } else {

            for (let i = 0; i < this.state.genres.length; ++i) {
                if (this.state.genres[i] === data.target.value) {
                    this.state.genres.splice(i, 1);
                }
            }
        }

        this.setState(
            {
                genresValid: this.state.genres.length > 0
            }
        );

    }

    submitHandler = (e) => {
        e.preventDefault();
        if (this.state.formIsValid()) {
            let requestBody =
            {
                Id: this.state.id,
                Name: this.state.name,
                Year: this.state.year,
                Authors: this.state.authors,
                Genres: this.state.genres
            }
            console.log(JSON.stringify(requestBody));

            let requestOptions =
            {
                method: 'patch',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(requestBody)
            };
            fetch("/api/book/" + this.state.id, requestOptions).then((response) => {
                console.log(response);
                if (response.ok) {
                    this.setState(
                        {
                            submitted: true
                        });
                }
            });
        }
    }


    render() {
        if (this.state.submitted === true) {
            return <Redirect to='/book-list' />
        }
        return (
            <div>
                <form className="form-group" onSubmit={this.submitHandler}>
                    <div className="form-group">
                        <label>Enter books name:
                            <input type="text" value={this.state.name} name="name" className="form-control" onChange={this.nameChangeHandler} />
                        </label>
                    </div>
                    <div className="form-group">
                        <label>Enter books year:
                            <input type="text" value={this.state.year} name="year" className="form-control" onChange={this.yearChangeHandler} />
                        </label>
                    </div>
                    <div className="row">
                        <div className="col">
                            <div className="row">

                                Can't find your author?
                                <Link style={{ textDecoration: 'none' }} to={{ pathname: '/author-create' }}> Feel free to add one! </Link>

                            </div>
                            <div className="form-group">
                                {this.state.availableAuthors.map(
                                    (author, index) =>
                                        <div key={index} className="custom-control custom-checkbox">
                                            <input checked={this.state.authors.includes(author.name)} name="author" value={author.name} onChange={this.authorsCheckedHandler} type="checkbox" className="custom-control-input" id={"customAuthorCheck" + author.id} />
                                            <label className="custom-control-label" htmlFor={"customAuthorCheck" + author.id}>{author.name}</label>
                                        </div>
                                )}
                            </div>
                        </div>
                        <div className="col">
                            <div className="row">

                                Can't find your genre?
                                <Link style={{ textDecoration: 'none' }} to={{ pathname: '/genre-create' }}> Feel free to add one! </Link>

                            </div>
                            <div className="form-group">
                                {this.state.availableGenres.map(
                                    (genre, index) =>
                                        <div key={index} className="custom-control custom-checkbox">
                                            <input checked={this.state.genres.includes(genre.name)} name="genre" value={genre.name} type="checkbox" onChange={this.genresCheckedHandler} className="custom-control-input" id={"customGenreCheck" + genre.id} />
                                            <label className="custom-control-label" htmlFor={"customGenreCheck" + genre.id}>{genre.name}</label>
                                        </div>
                                )}
                            </div>

                        </div>
                    </div>
                    {(this.state.formIsValid() && <div className="form-group"><button type="submit" className="btn btn-primary form-control">Submit</button></div>)}
                </form>
            </div>
        );
    }
}

export default BookEditForm