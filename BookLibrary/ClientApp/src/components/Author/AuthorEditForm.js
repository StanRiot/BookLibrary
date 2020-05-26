import React, { Component } from 'react'
import { Redirect } from "react-router-dom"

export class AuthorEditForm extends Component {
    constructor(props) {
        super(props);

        this.state =
        {
            id: this.props.location.props === undefined ? '' : this.props.location.props.id,
            name: this.props.location.props === undefined ? '' : this.props.location.props.name,
            isValid: true,
            submitted: false,
        };
    }
    nameChangeHandler = (data) => {
        this.setState(
            {
                name: data.target.value
            }
        );

        if (data.target.value != null && data.target.value.length > 0) {
            this.state.isValid = true;
        } else {
            this.state.isValid = false;
        }
    }
    submitEventHandler = (e) => {
        e.preventDefault();
        if (this.state.isValid) {
            let requestOptions =
            {
                method: 'patch',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ id: this.state.id, name: this.state.name })
            };
            fetch("/api/author/" + this.state.id, requestOptions).then((response) => {
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
        if (this.props.location.props === undefined || this.state.submitted === true) {
            return <Redirect to='/author-list' />
        }

        return (
            <div>
                <form onSubmit={this.submitEventHandler}>
                    <h2>Author edit form</h2>
                    <div className="form-group row">
                        <label>Name:
                        <input className="form-control" onChange={this.nameChangeHandler} type="text" name="name" value={this.state.name} />
                        </label>
                    </div>
                    <div className="form-group row">
                        {(this.state.isValid && <button className="btn btn-primary" type="submit">Submit</button>)}
                    </div>
                </form>
            </div>
        )
    }
}

export default AuthorEditForm