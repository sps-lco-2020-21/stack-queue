# Stacks and Queues

## Breadth-First / Shortest Path

Needs a FIFO: use a queue, add all the children to the back of the queue. This means that all the paths of specific length are exhausted first, before queues of the next length. 

## Depth-First / Existential Proof

Needs a LIFO: use a stack, add all the children to the head item to the head of the list so as to dive deep first, then backtrack. 

# Stack/Queue Questions

1. In the game of chess a knight can move between any two squares on the both. Use a queue to find the shortest path for a knight between two given squares. 
1. Use a queue to generate all possible binary numbers as strings. 
1. Implement a circular queue of size _n_, using integer variables to represent the front and the back. Insert more than _n_ variables and ensure that the appropriate, i.e. oldest, values are replaced. 
1. Consider a 2d array of integers, where the values represent different colour, consider how a queue might be used to 'flood fill' an area of the grid, i.e. starting from a given location with a target colour, all neighouring cells should be coloured the same colour. 
1. Use a stack to reverse a strings. 
1. Given a mathematical statement using parantheses, use a stack to check if the pairs balance.  
1. Implement a postfix calculator using a stack. 
