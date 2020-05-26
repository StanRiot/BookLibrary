import React, { Component } from 'react';
import { Link } from 'react-router-dom'
import BookRow from './BookRow'


export class BookTable extends Component {
    static displayName = this.name;

    constructor(props) {
        super(props);
        this.state = { bookList: [], loading: true };
    }

    componentDidMount() {
        this.populateListData();
    }

    static renderBookTable(bookList) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Year</th>
                        <th>Author</th>
                        <th>Genre</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {bookList.map(book =>
                        <BookRow key={book.id} book={book} />
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : BookTable.renderBookTable(this.state.bookList);

        return (
            <div>
                <h1 id="tabelLabel" >List of books</h1>
                <Link style={{ textDecoration: 'none', color: '#212529' }} to={{ pathname: '/book-create' }}>Create new book</Link>

                {contents}
            </div>
        );
    }

    async populateListData() {
        const response = await fetch('/api/book/list');
        const data = await response.json();
        this.setState({ bookList: data, loading: false });
    }
}
