import React from 'react'

import './Cart.css'

import ProductListItem from '../ProductListItem/'

const Cart = props => {

  const cartData = props.data;
  console.log(cartData)
  return (
    <div className="cart-container">
      <button onClick={props.clearCart}>Clear Cart</button>
      <button onClick={props.toggleCheckout}>Checkout</button>
      <h4>Cart</h4>
      {cartData.map((item, key) => <ProductListItem key={key} data={item.product_id} /> )}
    </div>
  )

}

export default Cart
