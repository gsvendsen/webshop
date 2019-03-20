import React, { Component } from 'react'
import ProductListItem from '../ProductListItem/'


import './Checkout.css'

class Checkout extends Component {
render () {
  return (
    <div className="checkout-container">
    <img className="exit-icon" onClick={this.props.toggleCheckout} height="25" width="25" src="https://image.flaticon.com/icons/svg/109/109602.svg"/>
    <h1>CHECKOUT!!!</h1>
    {this.props.cart.map(item => <ProductListItem data={item} /> )}
    </div>
  )
}
}

export default Checkout
