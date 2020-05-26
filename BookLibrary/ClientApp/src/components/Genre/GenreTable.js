import React, { Component } from 'react';
import GenreRow from './GenreRow'
import { Link } from "react-router-dom"


export class GenreTable extends Component {
    static displayName = this.name;

    constructor(props) {
        super(props);
        this.state = { genreList: [], loading: true };
    }

    componentDidMount() {
        this.populateListData();
    }

    static renderGenreTable(genreList) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {genreList.map(genre =>
                        <GenreRow key={genre.id} genre={genre} />
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : GenreTable.renderGenreTable(this.state.genreList);

        return (
            <div>
                <h1 id="tabelLabel" >List of genres</h1>
                <Link style={{ textDecoration: 'none', color:'#212529' }} to={{ pathname: '/genre-create'}}> Create new genre </Link>
                {contents}
            </div>
        );
    }

    async populateListData() {
        const response = await fetch('/api/genre/list');
        const data = await response.json();
        this.setState({ genreList: data, loading: false });
    }
}
export default GenreTable