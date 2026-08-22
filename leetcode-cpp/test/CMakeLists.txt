cmake_minimum_required(VERSION 3.26)

set(CMAKE_CXX_STANDARD 23)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

add_executable(
        leetcodecpp
        main.cpp
        pch.h
        pch.cpp
        add_two_numbers_unit_test.cpp
        all_one_unit_test.cpp
        all_possible_fbt_unit_test.cpp
        codec_unit_test.cpp
        exam_room_unit_test.cpp
        garbage_collection_unit_test.cpp
        print_order_unit_test.cpp
        print_order_unit_test.cpp
        randomized_set_unit_test.cpp
        solution_unit_test.cpp
        throne_inheritance_unit_test.cpp
        two_sum_unit_test.cpp
)

if (CMAKE_VERSION VERSION_GREATER 3.12)
    set_property(TARGET leetcodecpp PROPERTY CXX_STANDARD 23)
endif ()

target_link_libraries(
        leetcodecpp
        libleetcodecpp
        GTest::gtest_main)

include(GoogleTest)
gtest_discover_tests(leetcodecpp)