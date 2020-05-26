import React, { Component } from 'react'
import { Redirect, Link } from "react-router-dom"

export class GenreRow extends Component {
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
        fetch("/api/genre/" + this.props.genre.id, requestOptions).then((response) => {
            return response;
        }).then((result) => {
            if (result.ok) {
                this.setState(
                    {
                        isDeleted: true
                    });
            }
        });
    }



    render() {
        return !this.state.isDeleted && (
            <tr>
                <td>{this.props.genre.id}</td>
                <td>{this.props.genre.name}</td>
                <td>
                    <Link style={{ textDecoration: 'none', color: '#212529' }} to={{ pathname: '/genre-edit', props: { id: this.props.genre.id, name: this.props.genre.name } }}> Edit </Link> | <span onClick={this.onDeleteRequest}>Delete</span></td>
            </tr>
        );
    }
}


export default GenreRow