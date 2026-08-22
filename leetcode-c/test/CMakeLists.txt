cmake_minimum_required(VERSION 3.20)

set(CMAKE_C_STANDARD 17)
set(CMAKE_C_STANDARD_REQUIRED ON)

find_package(cmocka CONFIG REQUIRED)

add_executable(leetcodec
        main.c
        test_interview_solution.c
        test_solution.c
        test_atm.c
        pch.h
        pch.c
)

set_property(TARGET leetcodec PROPERTY C_STANDARD 17)

target_link_libraries(
        leetcodec
        PRIVATE cmocka::cmocka
        libleetcodec)

enable_testing()
add_test(NAME leetcodec_tests COMMAND leetcodec)