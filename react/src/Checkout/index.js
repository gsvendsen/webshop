import React from 'react'
import ProductListItem from '../ProductListItem/'

import ContactForm from '../ContactForm'

import './Checkout.css'

const Checkout = (props) => {

  let totalPrice = 0
  props.cart.forEach(item => {
    fetch(`http://localhost:5000/api/products/${item.product_id}`)
      .then(response => response.json())
      .then(response => {
        response.price += totalPrice
      })
  })

  return (
    <div className="checkout-container">
      <img alt="Exit button for checkout" className="exit-icon" onClick={props.toggleCheckout} height="25" width="25" src="https://image.flaticon.com/icons/svg/109/109602.svg"/>
      <h1>CHECKOUT</h1>
      <div className="checkout-list">
        {props.cart.map((item, key) => <ProductListItem key={key} data={item.product_id} /> )}
      </div>
      <p>
        Total Price: $ <i>{totalPrice}</i>
      </p>
      <ContactForm toggleCart={props.toggleCart} toggleCheckout={props.toggleCheckout} clearCart={props.clearCart} cartData={props.cart} submitOrder={props.submitOrder} />
    </div>
  )

}

export default Checkout
