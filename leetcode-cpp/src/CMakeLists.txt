cmake_minimum_required(VERSION 3.26)

set(CMAKE_CXX_STANDARD 23)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

add_library(libleetcodecpp STATIC
        all_one.h
        atm.h
        atm.cpp
        bst_iterator.h
        codec.h
        data_structure.h
        exam_room.h
        exam_room.cpp
        foo.h
        min_stack.h
        my_stack.h
        num_array.h
        randomized_set.h
        solution.h
        solution.cpp
        throne_inheritance.h
        throne_inheritance.cpp
        utils.h
        utils.cpp
)

target_include_directories(libleetcodecpp PUBLIC ${CMAKE_CURRENT_SOURCE_DIR})