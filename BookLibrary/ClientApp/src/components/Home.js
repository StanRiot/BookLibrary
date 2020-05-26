import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <h1>Book list application </h1>
                <p>This application is, has been built by Kostiantyn Kozakov using:</p>
                <ul>
                    <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
                    <li><a href='https://facebook.github.io/react/'>React</a> for client-side code</li>
                    <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
                </ul>
                <p>Contacts:</p>
                <ul>
                    <li><strong>Telegram:</strong>@Mesjour_Kjes</li>
                    <li><strong>LinkedIn</strong>. <a href="https://www.linkedin.com/in/%D0%BA%D0%BE%D0%BD%D1%81%D1%82%D0%B0%D0%BD%D1%82%D0%B8%D0%BD-%D0%BA%D0%BE%D0%B7%D0%B0%D0%BA%D0%BE%D0%B2-4ba6b6187/">Link</a> </li>
                </ul>
                <p>This project repository link: <a href="https://github.com/StanRiot/BookLibrary">github</a></p>
            </div>
        );
    }
}