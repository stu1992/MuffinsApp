import { Component } from 'react';
class MuffinView extends Component {
  render() {
    return <li>{this.props.type}</li>;
  }
}

export { MuffinView }