import React, {Component} from 'react'

class ContactForm extends Component {

  constructor() {
      super()
      this.state = {
          customer_name: "",
          customer_address: "",
          customer_phone: "",
          order_date: ""
      }
      this.handleChange = this.handleChange.bind(this)
      this.handleSubmit = this.handleSubmit.bind(this)
  }
  componentDidMount() {
    const currentdate = new Date();
    const dateTime = currentdate.getDate() + "/"
                + (currentdate.getMonth()+1)  + "/"
                + currentdate.getFullYear() + " @ "
                + currentdate.getHours() + ":"
                + currentdate.getMinutes() + ":"
                + currentdate.getSeconds()

    this.setState({ order_date: dateTime})
  }

  handleChange(event) {
    const {name, value} = event.target
    this.setState({ [name]: value })
  }

  handleSubmit(e) {
    e.preventDefault();
    this.props.toggleCheckout()
    this.setState({
      customer_name: "",
      customer_address: "",
      customer_telephone: ""
    })
  }

  render() {
    return (
      <div className="contact-form">
      <form onSubmit={(e) => {
        this.handleSubmit(e)
        this.props.submitOrder(this.state, this.props.cartData);
      }}>
                      <input
                          type="text"
                          value={this.state.name}
                          name="customer_name"
                          placeholder="Your name"
                          onChange={this.handleChange}
                      />
                      <input
                          type="text"
                          value={this.state.address}
                          name="customer_address"
                          placeholder="Address"
                          onChange={this.handleChange}
                      />
                      <input
                          type="text"
                          value={this.state.telephone}
                          name="customer_phone"
                          placeholder="Telephone Number"
                          onChange={this.handleChange}
                      />
                      <button>Submit</button>
                  </form>
      </div>
    )
  }
}

export default ContactForm
