//--------------------------------------------------------------------------------------------------
// <copyright company="NHL Stenden">
//     Author: Martin Bosgra
//     Copyright © NHL Stenden. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------------------------------

namespace Spune.Common.Handlers;

/// <summary>
/// Represents an asynchronous event handler method that handles an event with the specified event data.
/// </summary>
/// <typeparam name="TEventArgs">The type of the event data generated by the event.</typeparam>
/// <param name="sender">The source of the event.</param>
/// <param name="e">An object that contains the event data.</param>
/// <returns>A task that represents the asynchronous operation.</returns>
public delegate Task AsyncEventHandler<in TEventArgs>(object sender, TEventArgs e);
