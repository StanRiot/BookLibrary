import React, { Component } from 'react'
import { Link } from "react-router-dom"
export class BookRow extends Component {
    constructor(props) {
        super(props);
        this.state =
        {
            isDeleted: false
        }
    }
    onDeleteRequest = () => {
        let requestOptions =
        {
            method: "delete"
        }
        fetch("/api/book/" + this.props.book.id, requestOptions).then((response) => {
            return response;
        }).then((result) => {
            if (result.ok) {
                this.setState(
                    {
                        isDeleted: true
                    });
            }
            console.log(result);
        });


    }
    render() {
        return !this.state.isDeleted && (
            <tr>
                <td>{this.props.book.id}</td>
                <td>{this.props.book.name}</td>
                <td>{this.props.book.year}</td>
                <td>{this.props.book.authors.map((G) => <div key={G.id}>{G}</div>)}</td>
                <td>{this.props.book.genres.map((G) => <div key={G.id}>{G}</div>)}</td>
                <td><Link style={{ textDecoration: 'none', color: '#212529' }} to={{ pathname: '/book-edit', props: { book: this.props.book} }}> Edit </Link>| <span onClick={this.onDeleteRequest}>Delete</span></td>
            </tr>
        );
    }
}

export default BookRow