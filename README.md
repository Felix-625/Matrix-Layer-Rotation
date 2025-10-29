# Matrix-Layer-Rotation

This code rotates a matrix counter-clockwise by processing it in concentric layers, similar to peeling an onion. For each layer, it extracts all elements into a linear list, rotates them by the required number of positions using modular arithmetic to avoid full-circle rotations, then places the rotated elements back into their original positions. Finally, it prints the fully rotated matrix with each layer properly transformed after all rotations are completed.
